using FluentAssertions;
using PopLume.Application.Dtos;
using PopLume.Application.Validators;
using Xunit;

namespace PopLume.Tests.Unitarios.Validators;

public class ProdutoVariacaoValidatorsTests
{
    [Fact]
    public void CreateProdutoValidator_DeveAceitarVariacoesDeCoresDiferentes()
    {
        var dto = CriarProduto("Preto", "Azul", "Verde");

        var resultado = new CreateProdutoValidator().Validate(dto);

        resultado.IsValid.Should().BeTrue();
    }

    [Fact]
    public void CreateProdutoValidator_DeveRejeitarNomeDeVariacaoDuplicado()
    {
        var dto = CriarProduto("Preto", "preto");

        var resultado = new CreateProdutoValidator().Validate(dto);

        resultado.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ProdutoVariacaoInputValidator_DeveExigirFilamento()
    {
        var dto = new ProdutoVariacaoInputDto { Nome = "Preto", Filamentos = [] };

        new ProdutoVariacaoInputValidator().Validate(dto).IsValid.Should().BeFalse();
    }

    [Fact]
    public void ProdutoVariacaoInputValidator_DeveRejeitarFilamentoDuplicado()
    {
        var idFilamento = Guid.NewGuid();
        var dto = new ProdutoVariacaoInputDto
        {
            Nome = "Multicolorido",
            Filamentos =
            [
                new() { IdFilamento = idFilamento, QuantidadeGramas = 10 },
                new() { IdFilamento = idFilamento, QuantidadeGramas = 5 }
            ]
        };

        new ProdutoVariacaoInputValidator().Validate(dto).IsValid.Should().BeFalse();
    }

    private static CreateProdutoDto CriarProduto(params string[] cores) => new()
    {
        Nome = "Vaso Ondulado",
        Variacoes = cores.Select(cor => new ProdutoVariacaoInputDto
        {
            Nome = cor,
            Filamentos = [new ProdutoVariacaoFilamentoInputDto
            {
                IdFilamento = Guid.NewGuid(),
                QuantidadeGramas = 100
            }]
        }).ToList()
    };
}
