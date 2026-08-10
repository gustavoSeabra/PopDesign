using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Application.Mappers;

public static class InsumoMapper
{
    public static InsumoDto ToDto(this Insumo insumo) => new()
    {
        IdInsumo = insumo.IdInsumo,
        Nome = insumo.Nome,
        ValorCompra = insumo.ValorCompra,
        QuantidadeComprada = insumo.QuantidadeComprada,
        UnidadeMedida = insumo.UnidadeMedida,
        CustoUnitario = insumo.CalcularCustoUnitario()
    };

    public static Insumo ToEntity(this CreateInsumoDto dto) => new()
    {
        Nome = dto.Nome,
        ValorCompra = dto.ValorCompra!.Value,
        QuantidadeComprada = dto.QuantidadeComprada!.Value,
        UnidadeMedida = dto.UnidadeMedida!.Value
    };
}
