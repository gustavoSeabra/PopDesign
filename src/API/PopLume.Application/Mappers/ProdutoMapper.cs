using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Application.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(this Produto produto) => new()
    {
        IdProduto = produto.IdProduto,
        Nome = produto.Nome,
        PrecoCusto = produto.PrecoCusto,
        TempoImpressaoMinutos = produto.TempoImpressaoMinutos,
        TempoMaoDeObraMinutos = produto.TempoMaoDeObraMinutos,
        IdEquipamento = produto.IdEquipamento,
        Filamentos = produto.Filamentos.Select(x => new ProdutoFilamentoDto
        {
            IdFilamento = x.IdFilamento,
            Cor = x.Filamento?.Cor ?? string.Empty,
            QuantidadeGramas = x.QuantidadeGramas,
            PercentualPerda = x.PercentualPerda,
            Custo = x.Filamento is null ? 0 : x.CalcularCusto()
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
            PrecoCustoUnitario = x.ProdutoFilho?.PrecoCusto ?? 0
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

        AplicarRelacionamentos(produto, dto.Filamentos, dto.Insumos, dto.Componentes);
        return produto;
    }

    public static void AplicarRelacionamentos(
        Produto produto,
        IEnumerable<ProdutoFilamentoInputDto>? filamentos,
        IEnumerable<ProdutoInsumoInputDto>? insumos,
        IEnumerable<ProdutoComponenteDto>? componentes)
    {
        produto.Filamentos = filamentos?.Select(x => new ProdutoFilamento
        {
            IdFilamento = x.IdFilamento,
            QuantidadeGramas = x.QuantidadeGramas,
            PercentualPerda = x.PercentualPerda
        }).ToList() ?? [];

        produto.Insumos = insumos?.Select(x => new ProdutoInsumo
        {
            IdInsumo = x.IdInsumo,
            QuantidadeUtilizada = x.QuantidadeUtilizada
        }).ToList() ?? [];

        produto.ComposicoesPai = componentes?.Select(x => new ProdutoComposicao
        {
            IdProdutoFilho = x.IdProdutoFilho,
            Quantidade = x.Quantidade
        }).ToList() ?? [];
    }
}
