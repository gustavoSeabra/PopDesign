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
    public void ProdutoFilamento_DeveConsiderarPerda()
    {
        var uso = new ProdutoFilamento
        {
            QuantidadeGramas = 100,
            PercentualPerda = 5,
            Filamento = new Filamento { ValorCompra = 100, PesoLiquidoGramas = 1000 }
        };
        uso.CalcularCusto().Should().Be(10.5m);
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
    public void Produto_DeveImpedirCustoNegativo()
    {
        var produto = new Produto();
        var acao = () => produto.AtualizarPrecoCusto(-1);
        acao.Should().Throw<ArgumentOutOfRangeException>();
    }
}
