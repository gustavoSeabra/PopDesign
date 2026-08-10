using Bogus;
using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Tests.Mocks.Dtos;

public static class ProdutoDtoMock
{
    private static readonly Faker Faker = new("pt_BR");

    public static CreateProdutoDto CreateProdutoDtoSemComponentes() => new()
    {
        Nome = Faker.Commerce.ProductName(),
        TempoImpressaoMinutos = 0,
        TempoMaoDeObraMinutos = 0,
        Filamentos = [],
        Insumos = [],
        Componentes = []
    };

    public static CreateProdutoDto CreateProdutoDtoComComponentes(int quantidadeComponentes = 2) => new()
    {
        Nome = Faker.Commerce.ProductName(),
        TempoImpressaoMinutos = Faker.Random.Int(10, 600),
        TempoMaoDeObraMinutos = Faker.Random.Int(1, 60),
        Componentes = ProdutoComponentesDto(quantidadeComponentes)
    };

    public static UpdateProdutoDto UpdateProdutoDtoSemComponentes(Guid? idProduto = null) => new()
    {
        IdProduto = idProduto ?? Guid.NewGuid(),
        Nome = Faker.Commerce.ProductName(),
        TempoImpressaoMinutos = 0,
        TempoMaoDeObraMinutos = 0,
        Filamentos = [],
        Insumos = [],
        Componentes = []
    };

    public static UpdateProdutoDto UpdateProdutoDtoComComponentes(Guid? idProduto = null, int quantidadeComponentes = 2) => new()
    {
        IdProduto = idProduto ?? Guid.NewGuid(),
        Nome = Faker.Commerce.ProductName(),
        TempoImpressaoMinutos = Faker.Random.Int(10, 600),
        TempoMaoDeObraMinutos = Faker.Random.Int(1, 60),
        Componentes = ProdutoComponentesDto(quantidadeComponentes)
    };

    public static Produto ProdutoValido(Guid? idProduto = null, string? nome = null)
    {
        var produto = new Produto
        {
            IdProduto = idProduto ?? Guid.NewGuid(),
            Nome = nome ?? Faker.Commerce.ProductName(),
            TempoImpressaoMinutos = Faker.Random.Int(10, 600),
            TempoMaoDeObraMinutos = Faker.Random.Int(1, 60),
            ComposicoesPai = []
        };
        produto.AtualizarPrecoCusto(Faker.Random.Decimal(10, 250));
        return produto;
    }

    public static List<Produto> ProdutosValidos(int quantidade = 3) =>
        Enumerable.Range(0, quantidade).Select(_ => ProdutoValido()).ToList();

    private static List<ProdutoComponenteDto> ProdutoComponentesDto(int quantidade) =>
        Enumerable.Range(0, quantidade).Select(_ => new ProdutoComponenteDto
        {
            IdProdutoFilho = Guid.NewGuid(),
            Quantidade = Faker.Random.Int(1, 10)
        }).ToList();
}
