using FluentAssertions;
using PopLume.Domain.Precificacao;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class CalculadoraPrecificacaoTests
{
    [Fact]
    public void Calcular_DeveDetalharTodosOsCustos()
    {
        var parametros = new ParametrosPrecificacao(
            Filamentos: [new ItemCusto("PLA", 10m, 0.10m)],
            Insumos: [new ItemCusto("Argola", 1m, 0.40m)],
            Componentes: [new ItemCusto("Componente", 2m, 1m)],
            TempoImpressaoMinutos: 120,
            TempoMaoDeObraMinutos: 30,
            PotenciaWatts: 150,
            ValorKwh: 1.50m,
            CustoDepreciacaoHora: 0.60m,
            ValorMaoDeObraHora: 12m,
            MargemPercentual: 40m);

        var resultado = CalculadoraPrecificacao.Calcular(parametros);

        resultado.CustoFilamentos.Should().Be(1m);
        resultado.CustoInsumos.Should().Be(0.40m);
        resultado.CustoComponentes.Should().Be(2m);
        resultado.CustoEnergia.Should().Be(0.45m);
        resultado.CustoEquipamento.Should().Be(1.20m);
        resultado.CustoMaoDeObra.Should().Be(6m);
        resultado.CustoTotalLote.Should().Be(11.05m);
        resultado.PrecoVenda.Should().Be(18.42m);
    }

    [Fact]
    public void Calcular_DeveRatearCustoDoLote()
    {
        var parametros = CriarParametros() with
        {
            Insumos = [new ItemCusto("Caixa", 1, 10)],
            QuantidadeProduzida = 4
        };

        var resultado = CalculadoraPrecificacao.Calcular(parametros);

        resultado.CustoTotalLote.Should().Be(10);
        resultado.CustoUnitario.Should().Be(2.5m);
    }

    [Fact]
    public void Calcular_DeveConsiderarComissaoETaxaFixa()
    {
        var parametros = CriarParametros() with
        {
            Insumos = [new ItemCusto("Produto", 1, 10)],
            MargemPercentual = 30,
            ComissaoPercentual = 15,
            TaxaFixa = 2
        };

        var resultado = CalculadoraPrecificacao.Calcular(parametros);

        resultado.PrecoVenda.Should().Be(21.82m);
        resultado.ValorComissao.Should().Be(3.273m);
    }

    [Fact]
    public void Calcular_DeveRejeitarMargemMaisComissaoIgualACem()
    {
        var parametros = CriarParametros() with { MargemPercentual = 70, ComissaoPercentual = 30 };

        var acao = () => CalculadoraPrecificacao.Calcular(parametros);

        acao.Should().Throw<InvalidOperationException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Calcular_DeveRejeitarQuantidadeProduzidaInvalida(int quantidade)
    {
        var acao = () => CalculadoraPrecificacao.Calcular(CriarParametros() with { QuantidadeProduzida = quantidade });
        acao.Should().Throw<ArgumentOutOfRangeException>();
    }

    private static ParametrosPrecificacao CriarParametros() => new(
        [], [], [], 0, 0, 0, 0, 0, 0, 0);
}
