using FluentAssertions;
using PopLume.Domain.Entities;
using PopLume.Domain.Enums;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class CustosDeMateriaisTests
{
    [Fact]
    public void Filamento_DeveCalcularCustoPorGrama()
    {
        var filamento = new Filamento { ValorCompra = 85.41m, PesoLiquidoGramas = 1000m };
        filamento.CalcularCustoPorGrama().Should().Be(0.08541m);
    }

    [Fact]
    public void ProdutoVariacaoFilamento_DeveConsiderarPerda()
    {
        var uso = new ProdutoVariacaoFilamento
        {
            QuantidadeGramas = 100,
            PercentualPerda = 5,
            Filamento = new Filamento { ValorCompra = 100, PesoLiquidoGramas = 1000 }
        };
        uso.CalcularCusto().Should().Be(10.5m);
    }

    [Fact]
    public void ProdutoVariacao_DeveManterCustoProprio()
    {
        var variacao = new ProdutoVariacao { Nome = "Azul" };

        variacao.AtualizarPrecoCusto(12.50m);

        variacao.PrecoCusto.Should().Be(12.50m);
    }

    [Fact]
    public void ProdutoInsumo_DevePermitirQuantidadeFracionada()
    {
        var uso = new ProdutoInsumo
        {
            QuantidadeUtilizada = 0.5m,
            Insumo = new Insumo
            {
                Nome = "Fita",
                ValorCompra = 20,
                QuantidadeComprada = 50,
                UnidadeMedida = UnidadeMedida.Metro
            }
        };
        uso.CalcularCusto().Should().Be(0.20m);
    }

    [Fact]
    public void ProdutoVariacao_DeveImpedirCustoNegativo()
    {
        var variacao = new ProdutoVariacao();
        var acao = () => variacao.AtualizarPrecoCusto(-1);
        acao.Should().Throw<ArgumentOutOfRangeException>();
    }
}
