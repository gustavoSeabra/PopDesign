using Microsoft.Extensions.Logging;
using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;
using PopLume.Domain.Entities;
using PopLume.Domain.Enums;
using PopLume.Domain.Precificacao;
using PopLume.Domain.Repositories;

namespace PopLume.Application.Services;

public class PrecificacaoService(
    IProdutoRepository produtoRepository,
    IEquipamentoRepository equipamentoRepository,
    ITarifaEnergiaRepository tarifaEnergiaRepository,
    ICustoMaoDeObraRepository custoMaoDeObraRepository,
    IMarketplaceRepository marketplaceRepository,
    IFichaPrecificacaoRepository fichaRepository,
    ILogger<PrecificacaoService> logger) : IPrecificacaoService
{
    public Task<ResultadoDto<PrecificacaoDto>> SimularAsync(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken = default) =>
        ExecutarAsync(idProduto, dto, persistir: false, cancellationToken);

    public Task<ResultadoDto<PrecificacaoDto>> CalcularESalvarAsync(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken = default) =>
        ExecutarAsync(idProduto, dto, persistir: true, cancellationToken);

    public async Task<ResultadoDto<IEnumerable<PrecificacaoDto>>> ObterHistoricoAsync(Guid idProduto, CancellationToken cancellationToken = default)
    {
        var fichas = await fichaRepository.ObterPorProdutoAsync(idProduto, cancellationToken);
        return ResultadoDto<IEnumerable<PrecificacaoDto>>.RetornaSucesso(fichas.Select(Mapear));
    }

    private async Task<ResultadoDto<PrecificacaoDto>> ExecutarAsync(
        Guid idProduto,
        CalcularPrecificacaoDto dto,
        bool persistir,
        CancellationToken cancellationToken)
    {
        try
        {
            var produto = await produtoRepository.ObterParaPrecificacaoAsync(idProduto, cancellationToken);
            if (produto is null)
                return ResultadoDto<PrecificacaoDto>.RetornaNaoEncontrado("Produto não encontrado.");

            var variacao = produto.Variacoes.FirstOrDefault(x => x.IdProdutoVariacao == dto.IdProdutoVariacao);
            if (variacao is null)
                return ResultadoDto<PrecificacaoDto>.RetornaNaoEncontrado("Variação do produto não encontrada.");
            if (!variacao.Ativa)
                return ResultadoDto<PrecificacaoDto>.RetornaErro("A variação selecionada está inativa.");

            var equipamento = await equipamentoRepository.ObterEquipamentosPorIdAsync(dto.IdEquipamento, cancellationToken);
            if (equipamento is null)
                return ResultadoDto<PrecificacaoDto>.RetornaNaoEncontrado("Equipamento não encontrado.");

            var hoje = DateOnly.FromDateTime(DateTime.UtcNow);
            var tarifaEnergia = await tarifaEnergiaRepository.ObterVigenteAsync(hoje, cancellationToken);
            if (tarifaEnergia is null)
                return ResultadoDto<PrecificacaoDto>.RetornaErro("Não existe tarifa de energia vigente.");

            var maoDeObra = await custoMaoDeObraRepository.ObterVigenteAsync(hoje, cancellationToken);
            if (maoDeObra is null)
                return ResultadoDto<PrecificacaoDto>.RetornaErro("Não existe custo de mão de obra vigente.");

            var filamentos = variacao.Filamentos.Select(x => new ItemCusto(
                $"Filamento {x.Filamento.Cor}",
                x.CalcularQuantidadeComPerda(),
                x.Filamento.CalcularCustoPorGrama())).ToArray();
            var insumos = produto.Insumos.Select(x => new ItemCusto(
                x.Insumo.Nome,
                x.QuantidadeUtilizada,
                x.Insumo.CalcularCustoUnitario())).ToArray();

            var componenteSemCusto = produto.ComposicoesPai.FirstOrDefault(x => x.ProdutoVariacaoFilho.PrecoCusto <= 0);
            if (componenteSemCusto is not null)
                return ResultadoDto<PrecificacaoDto>.RetornaErro($"A variação '{componenteSemCusto.ProdutoVariacaoFilho.Nome}' do componente '{componenteSemCusto.ProdutoFilho.Nome}' ainda não possui custo calculado.");

            var componentes = produto.ComposicoesPai.Select(x => new ItemCusto(
                $"{x.ProdutoFilho.Nome} - {x.ProdutoVariacaoFilho.Nome}",
                x.Quantidade,
                x.ProdutoVariacaoFilho.PrecoCusto)).ToArray();

            var parametrosBase = new ParametrosPrecificacao(
                filamentos,
                insumos,
                componentes,
                produto.TempoImpressaoMinutos,
                produto.TempoMaoDeObraMinutos,
                equipamento.PotenciaWatts,
                tarifaEnergia.ValorKwh,
                equipamento.CustoDepreciacaoHora,
                maoDeObra.ValorHora,
                dto.MargemPercentual,
                QuantidadeProduzida: dto.QuantidadeProduzida);

            Marketplace? marketplace = null;
            TaxasMarketplace? taxaSelecionada = null;
            ResultadoPrecificacao resultado;

            if (dto.IdMarketplace.HasValue)
            {
                marketplace = await marketplaceRepository.ObterMarketplacePorIdAsync(dto.IdMarketplace.Value, cancellationToken);
                if (marketplace is null)
                    return ResultadoDto<PrecificacaoDto>.RetornaNaoEncontrado("Marketplace não encontrado.");

                (taxaSelecionada, resultado) = SeletorTaxaMarketplace.Selecionar(marketplace.TaxasMarketplace, parametrosBase);
                if (taxaSelecionada is null)
                    return ResultadoDto<PrecificacaoDto>.RetornaErro("Nenhuma faixa do marketplace corresponde ao preço calculado.");
            }
            else
            {
                resultado = CalculadoraPrecificacao.Calcular(parametrosBase);
            }

            FichaPrecificacao? ficha = null;
            if (persistir)
            {
                ficha = CriarFicha(produto, variacao, equipamento, tarifaEnergia, maoDeObra, marketplace, taxaSelecionada, dto, resultado, filamentos, insumos, componentes);
                variacao.AtualizarPrecoCusto(resultado.CustoUnitario);
                fichaRepository.Adicionar(ficha);
                produtoRepository.Atualizar(produto);
                await fichaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }

            return ResultadoDto<PrecificacaoDto>.RetornaSucesso(Mapear(resultado, produto.IdProduto, variacao, ficha));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao precificar produto {ProdutoId}.", idProduto);
            return ResultadoDto<PrecificacaoDto>.RetornaErro(ex.Message);
        }
    }

    private static FichaPrecificacao CriarFicha(
        Produto produto,
        ProdutoVariacao variacao,
        Equipamento equipamento,
        TarifaEnergia tarifa,
        CustoMaoDeObra maoDeObra,
        Marketplace? marketplace,
        TaxasMarketplace? taxa,
        CalcularPrecificacaoDto dto,
        ResultadoPrecificacao resultado,
        IEnumerable<ItemCusto> filamentos,
        IEnumerable<ItemCusto> insumos,
        IEnumerable<ItemCusto> componentes)
    {
        var ficha = new FichaPrecificacao
        {
            IdProduto = produto.IdProduto,
            IdProdutoVariacao = variacao.IdProdutoVariacao,
            IdEquipamento = equipamento.IdEquipamento,
            IdTarifaEnergia = tarifa.IdTarifaEnergia,
            IdCustoMaoDeObra = maoDeObra.IdCustoMaoDeObra,
            IdMarketplace = marketplace?.IdMarketplace,
            IdTaxaMarketplace = taxa?.IdTaxa,
            CalculadaEmUtc = DateTime.UtcNow,
            QuantidadeProduzida = dto.QuantidadeProduzida,
            MargemPercentual = dto.MargemPercentual,
            ComissaoPercentual = taxa?.ComissaoPercentual ?? 0,
            TaxaFixa = resultado.TaxaFixa,
            CustoFilamentos = resultado.CustoFilamentos,
            CustoInsumos = resultado.CustoInsumos,
            CustoComponentes = resultado.CustoComponentes,
            CustoEnergia = resultado.CustoEnergia,
            CustoEquipamento = resultado.CustoEquipamento,
            CustoMaoDeObra = resultado.CustoMaoDeObra,
            CustoTotalLote = resultado.CustoTotalLote,
            CustoUnitario = resultado.CustoUnitario,
            ValorComissao = resultado.ValorComissao,
            LucroUnitario = resultado.LucroUnitario,
            PrecoVenda = resultado.PrecoVenda
        };

        var horasImpressao = produto.TempoImpressaoMinutos / 60m;
        var horasMaoDeObra = produto.TempoMaoDeObraMinutos / 60m;
        var consumoKwh = equipamento.PotenciaWatts * horasImpressao / 1000m;

        ficha.Itens = CriarItens(filamentos, TipoItemPrecificacao.Filamento)
            .Concat(CriarItens(insumos, TipoItemPrecificacao.Insumo))
            .Concat(CriarItens(componentes, TipoItemPrecificacao.ProdutoComponente))
            .Append(CriarItem("Energia elétrica", TipoItemPrecificacao.Energia, consumoKwh, tarifa.ValorKwh))
            .Append(CriarItem($"Equipamento {equipamento.Nome}", TipoItemPrecificacao.Equipamento, horasImpressao, equipamento.CustoDepreciacaoHora))
            .Append(CriarItem("Mão de obra", TipoItemPrecificacao.MaoDeObra, horasMaoDeObra, maoDeObra.ValorHora))
            .Concat(taxa is null
                ? Enumerable.Empty<ItemFichaPrecificacao>()
                : new[] { CriarItem($"Taxas {marketplace!.Nome}", TipoItemPrecificacao.TaxaMarketplace, 1, resultado.TaxaFixa + resultado.ValorComissao) })
            .ToList();
        return ficha;
    }

    private static IEnumerable<ItemFichaPrecificacao> CriarItens(IEnumerable<ItemCusto> itens, TipoItemPrecificacao tipo) =>
        itens.Select(x => new ItemFichaPrecificacao
        {
            Tipo = tipo,
            Descricao = x.Descricao,
            Quantidade = x.Quantidade,
            ValorUnitario = x.ValorUnitario,
            ValorTotal = x.Total
        });

    private static ItemFichaPrecificacao CriarItem(
        string descricao,
        TipoItemPrecificacao tipo,
        decimal quantidade,
        decimal valorUnitario) => new()
    {
        Tipo = tipo,
        Descricao = descricao,
        Quantidade = quantidade,
        ValorUnitario = valorUnitario,
        ValorTotal = quantidade * valorUnitario
    };

    private static PrecificacaoDto Mapear(ResultadoPrecificacao x, Guid idProduto, ProdutoVariacao variacao, FichaPrecificacao? ficha) => new()
    {
        IdFichaPrecificacao = ficha?.IdFichaPrecificacao,
        IdProduto = idProduto,
        IdProdutoVariacao = variacao.IdProdutoVariacao,
        VariacaoNome = variacao.Nome,
        CalculadaEmUtc = ficha?.CalculadaEmUtc,
        CustoFilamentos = x.CustoFilamentos,
        CustoInsumos = x.CustoInsumos,
        CustoComponentes = x.CustoComponentes,
        CustoEnergia = x.CustoEnergia,
        CustoEquipamento = x.CustoEquipamento,
        CustoMaoDeObra = x.CustoMaoDeObra,
        CustoTotalLote = x.CustoTotalLote,
        CustoUnitario = x.CustoUnitario,
        ValorComissao = x.ValorComissao,
        TaxaFixa = x.TaxaFixa,
        LucroUnitario = x.LucroUnitario,
        PrecoVenda = x.PrecoVenda
    };

    private static PrecificacaoDto Mapear(FichaPrecificacao x) => new()
    {
        IdFichaPrecificacao = x.IdFichaPrecificacao,
        IdProduto = x.IdProduto,
        IdProdutoVariacao = x.IdProdutoVariacao,
        VariacaoNome = x.ProdutoVariacao?.Nome ?? string.Empty,
        CalculadaEmUtc = x.CalculadaEmUtc,
        CustoFilamentos = x.CustoFilamentos,
        CustoInsumos = x.CustoInsumos,
        CustoComponentes = x.CustoComponentes,
        CustoEnergia = x.CustoEnergia,
        CustoEquipamento = x.CustoEquipamento,
        CustoMaoDeObra = x.CustoMaoDeObra,
        CustoTotalLote = x.CustoTotalLote,
        CustoUnitario = x.CustoUnitario,
        ValorComissao = x.ValorComissao,
        TaxaFixa = x.TaxaFixa,
        LucroUnitario = x.LucroUnitario,
        PrecoVenda = x.PrecoVenda
    };
}
