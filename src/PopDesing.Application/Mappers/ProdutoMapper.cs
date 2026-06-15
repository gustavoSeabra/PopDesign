using PopDesing.Application.Dtos;
using PopDesing.Domain.Entities;

namespace PopDesing.Application.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(this Produto produto)
    {
        if (produto == null) return null!;

        return new ProdutoDto
        {
            IdProduto = produto.IdProduto,
            Nome = produto.Nome,
            PrecoCusto = produto.PrecoCusto,
            QuantidadeFilamento = produto.QuantidadeFilamento,
            TempoImpressao = produto.TempoImpressao,
            Componentes = produto.ComposicoesPai?.Select(c => ToDto(c.ProdutoFilho)).ToList()
        };
    }

    public static Produto ToEntity(this CreateProdutoDto dto)
    {
        if (dto == null) return null!;

        return new Produto
        {
            Nome = dto.Nome,
            PrecoCusto = dto.PrecoCusto,
            QuantidadeFilamento = dto.QuantidadeFilamento,
            TempoImpressao = dto.TempoImpressao,
            ComposicoesPai = dto.Componentes?.Select(c => new ProdutoComposicao
            {
                IdProdutoFilho = c.IdProdutoFilho,
                Quantidade = c.Quantidade
            }).ToList() ?? new List<ProdutoComposicao>()
        };
    }
}