using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Application.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(this Produto produto) => new()
    {
        IdProduto = produto.IdProduto,
        Nome = produto.Nome,
        TempoImpressaoMinutos = produto.TempoImpressaoMinutos,
        TempoMaoDeObraMinutos = produto.TempoMaoDeObraMinutos,
        IdEquipamento = produto.IdEquipamento,
        Variacoes = produto.Variacoes.Select(x => new ProdutoVariacaoDto
        {
            IdProdutoVariacao = x.IdProdutoVariacao,
            Nome = x.Nome,
            CodigoInterno = x.CodigoInterno,
            Ativa = x.Ativa,
            PrecoCusto = x.PrecoCusto,
            Filamentos = x.Filamentos.Select(f => new ProdutoVariacaoFilamentoDto
            {
                IdFilamento = f.IdFilamento,
                Cor = f.Filamento?.Cor ?? string.Empty,
                QuantidadeGramas = f.QuantidadeGramas,
                PercentualPerda = f.PercentualPerda,
                Custo = f.Filamento is null ? 0 : f.CalcularCusto()
            }).ToList()
        }).ToList(),
        Insumos = produto.Insumos.Select(x => new ProdutoInsumoDto
        {
            IdInsumo = x.IdInsumo,
            Nome = x.Insumo?.Nome ?? string.Empty,
            QuantidadeUtilizada = x.QuantidadeUtilizada,
            Custo = x.Insumo is null ? 0 : x.CalcularCusto()
        }).ToList(),
        Componentes = produto.ComposicoesPai.Select(x => new ProdutoComponenteDto
        {
            IdProdutoFilho = x.IdProdutoFilho,
            Nome = x.ProdutoFilho?.Nome ?? string.Empty,
            Quantidade = x.Quantidade,
            IdProdutoVariacaoFilho = x.IdProdutoVariacaoFilho,
            PrecoCustoUnitario = x.ProdutoVariacaoFilho?.PrecoCusto ?? 0
        }).ToList()
    };

    public static Produto ToEntity(this CreateProdutoDto dto)
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            TempoImpressaoMinutos = dto.TempoImpressaoMinutos ?? 0,
            TempoMaoDeObraMinutos = dto.TempoMaoDeObraMinutos ?? 0,
            IdEquipamento = dto.IdEquipamento
        };

        AplicarRelacionamentos(produto, dto.Variacoes, dto.Insumos, dto.Componentes);
        return produto;
    }

    public static void AplicarRelacionamentos(
        Produto produto,
        IEnumerable<ProdutoVariacaoInputDto>? variacoes,
        IEnumerable<ProdutoInsumoInputDto>? insumos,
        IEnumerable<ProdutoComponenteDto>? componentes)
    {
        produto.Variacoes = variacoes?.Select(x =>
        {
            var variacao = new ProdutoVariacao
            {
                IdProdutoVariacao = x.IdProdutoVariacao,
                Nome = x.Nome,
                CodigoInterno = x.CodigoInterno,
                Ativa = x.Ativa,
                Filamentos = x.Filamentos.Select(f => new ProdutoVariacaoFilamento
                {
                    IdFilamento = f.IdFilamento,
                    QuantidadeGramas = f.QuantidadeGramas,
                    PercentualPerda = f.PercentualPerda
                }).ToList()
            };
            return variacao;
        }).ToList() ?? [];

        produto.Insumos = insumos?.Select(x => new ProdutoInsumo
        {
            IdInsumo = x.IdInsumo,
            QuantidadeUtilizada = x.QuantidadeUtilizada
        }).ToList() ?? [];

        produto.ComposicoesPai = componentes?.Select(x => new ProdutoComposicao
        {
            IdProdutoFilho = x.IdProdutoFilho,
            IdProdutoVariacaoFilho = x.IdProdutoVariacaoFilho,
            Quantidade = x.Quantidade
        }).ToList() ?? [];
    }
}
