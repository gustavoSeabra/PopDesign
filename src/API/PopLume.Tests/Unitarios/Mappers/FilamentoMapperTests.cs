using FluentAssertions;
using PopLume.Application.Mappers;
using PopLume.Domain.Enums;
using PopLume.Tests.Mocks.Dtos;
using Xunit;

namespace PopLume.Tests.Unitarios.Mappers;

public class FilamentoMapperTests
{
    [Fact(DisplayName = "Deve mapear filamento para DTO.")]
    public void ToDto_DeveMapearTodosOsCampos()
    {
        var filamento = FilamentoDtoMock.FilamentoValido();

        var dto = filamento.ToDto();

        dto.IdFilamento.Should().Be(filamento.IdFilamento);
        dto.Cor.Should().Be(filamento.Cor);
        dto.ValorCompra.Should().Be(filamento.ValorCompra);
        dto.PesoLiquidoGramas.Should().Be(filamento.PesoLiquidoGramas);
        dto.Tipo.Should().Be(filamento.Tipo);
        dto.DataCompra.Should().Be(filamento.DataCompra);
    }

    [Fact(DisplayName = "Deve mapear DTO de criação para filamento.")]
    public void ToEntity_DeveMapearPesoEmGramasETipo()
    {
        var dto = FilamentoDtoMock.CreateFilamentoDtoValido();
        dto.PesoLiquidoGramas = 1000;
        dto.Tipo = TipoFilamento.PLA;

        var filamento = dto.ToEntity();

        filamento.PesoLiquidoGramas.Should().Be(1000);
        filamento.Tipo.Should().Be(TipoFilamento.PLA);
        filamento.Cor.Should().Be(dto.Cor);
        filamento.ValorCompra.Should().Be(dto.ValorCompra);
        filamento.DataCompra.Should().Be(dto.DataCompra);
    }
}
