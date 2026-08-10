using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Application.Mappers;

public static class FilamentoMapper
{
    public static FilamentoDto ToDto(this Filamento filamento) =>
        new()
        {
            IdFilamento = filamento.IdFilamento,
            Cor = filamento.Cor,
            ValorCompra = filamento.ValorCompra,
            PesoLiquidoGramas = filamento.PesoLiquidoGramas,
            Tipo = filamento.Tipo,
            DataCompra = filamento.DataCompra
        };

    public static Filamento ToEntity(this CreateFilamentoDto dto) =>
        new()
        {
            Cor = dto.Cor,
            ValorCompra = dto.ValorCompra!.Value,
            PesoLiquidoGramas = dto.PesoLiquidoGramas!.Value,
            Tipo = dto.Tipo!.Value,
            DataCompra = dto.DataCompra!.Value
        };
}
