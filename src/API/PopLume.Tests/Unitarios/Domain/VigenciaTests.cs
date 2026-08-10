using FluentAssertions;
using PopLume.Domain.Entities;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class VigenciaTests
{
    [Fact]
    public void TarifaEnergia_DeveReconhecerDataDentroDaVigencia()
    {
        var tarifa = new TarifaEnergia
        {
            InicioVigencia = new DateOnly(2026, 1, 1),
            FimVigencia = new DateOnly(2026, 12, 31)
        };
        tarifa.EstaVigenteEm(new DateOnly(2026, 6, 1)).Should().BeTrue();
        tarifa.EstaVigenteEm(new DateOnly(2027, 1, 1)).Should().BeFalse();
    }

    [Fact]
    public void CustoMaoDeObraSemFim_DevePermanecerVigente()
    {
        var custo = new CustoMaoDeObra { InicioVigencia = new DateOnly(2026, 1, 1) };
        custo.EstaVigenteEm(new DateOnly(2030, 1, 1)).Should().BeTrue();
    }
}
