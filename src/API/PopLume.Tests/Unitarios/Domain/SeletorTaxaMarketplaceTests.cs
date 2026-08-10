using FluentAssertions;
using PopLume.Domain.Entities;
using PopLume.Domain.Precificacao;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class SeletorTaxaMarketplaceTests
{
    [Fact]
    public void Selecionar_DeveUsarFaixaQueContemOPrecoCalculado()
    {
        TaxasMarketplace[] taxas =
        [
            new() { IdTaxa = Guid.NewGuid(), ValorInicial = 0, ValorFinal = 20, ComissaoPercentual = 10, TaxaFixa = 1 },
            new() { IdTaxa = Guid.NewGuid(), ValorInicial = 20.01m, ValorFinal = null, ComissaoPercentual = 15, TaxaFixa = 2 }
        ];
        var parametros = new ParametrosPrecificacao(
            [], [new ItemCusto("Custo", 1, 10)], [], 0, 0, 0, 0, 0, 0, 20);

        var (taxa, resultado) = SeletorTaxaMarketplace.Selecionar(taxas, parametros);

        taxa.Should().NotBeNull();
        taxa!.IdTaxa.Should().Be(taxas[0].IdTaxa);
        resultado.PrecoVenda.Should().Be(15.71m);
    }

    [Fact]
    public void Selecionar_DeveRetornarNuloQuandoHaBuracoNasFaixas()
    {
        TaxasMarketplace[] taxas =
        [
            new() { ValorInicial = 0, ValorFinal = 5, ComissaoPercentual = 10 }
        ];
        var parametros = new ParametrosPrecificacao(
            [], [new ItemCusto("Custo", 1, 10)], [], 0, 0, 0, 0, 0, 0, 20);

        var (taxa, _) = SeletorTaxaMarketplace.Selecionar(taxas, parametros);

        taxa.Should().BeNull();
    }
}
