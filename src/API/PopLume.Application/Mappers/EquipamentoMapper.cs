using PopLume.Application.Dtos;
using PopLume.Domain.Entities;

namespace PopLume.Application.Mappers;

public static class EquipamentoMapper
{
    public static EquipamentoDto ToDto(this Equipamento equipamento)
    {
        if (equipamento == null) return null!;

        return new EquipamentoDto
        {
            IdEquipamento = equipamento.IdEquipamento,
            Nome = equipamento.Nome,
            Apelido = equipamento.Apelido,
            DataCompra = equipamento.DataCompra,
            PotenciaWatts = equipamento.PotenciaWatts,
            ValorCompra = equipamento.ValorCompra,
            VidaUtilHoras = equipamento.VidaUtilHoras,
            CustoDepreciacaoHora = equipamento.CustoDepreciacaoHora,
            Excluido = equipamento.Excluido,
            DataExclusao = equipamento.DataExclusao
        };
    }

    public static Equipamento ToEntity(this CreateEquipamentoDto dto)
    {
        if (dto == null) return null!;

        return new Equipamento
        {
            Nome = dto.Nome,
            Apelido = dto.Apelido,
            DataCompra = dto.DataCompra!.Value,
            PotenciaWatts = dto.PotenciaWatts ?? 0,
            ValorCompra = dto.ValorCompra ?? 0m,
            VidaUtilHoras = dto.VidaUtilHoras ?? 0
        };
    }
}
