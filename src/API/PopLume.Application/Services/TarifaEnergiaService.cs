using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;

namespace PopLume.Application.Services;

public class TarifaEnergiaService(ITarifaEnergiaRepository repository) : ITarifaEnergiaService
{
    public async Task<ResultadoDto<IEnumerable<TarifaEnergiaDto>>> ObterTodasAsync(CancellationToken cancellationToken = default) =>
        ResultadoDto<IEnumerable<TarifaEnergiaDto>>.RetornaSucesso((await repository.ObterTodasAsync(cancellationToken)).Select(Mapear));

    public async Task<ResultadoDto<TarifaEnergiaDto?>> ObterVigenteAsync(CancellationToken cancellationToken = default)
    {
        var item = await repository.ObterVigenteAsync(DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
        return item is null ? ResultadoDto<TarifaEnergiaDto?>.RetornaNaoEncontrado("Não existe tarifa de energia vigente.")
            : ResultadoDto<TarifaEnergiaDto?>.RetornaSucesso(Mapear(item));
    }

    public async Task<ResultadoDto<Guid>> AdicionarAsync(CreateTarifaEnergiaDto dto, CancellationToken cancellationToken = default)
    {
        if (await repository.ExisteSobreposicaoAsync(dto.InicioVigencia!.Value, dto.FimVigencia, cancellationToken: cancellationToken))
            return ResultadoDto<Guid>.RetornaErro("A vigência informada se sobrepõe a outra tarifa de energia.");
        var item = new TarifaEnergia { ValorKwh = dto.ValorKwh!.Value, InicioVigencia = dto.InicioVigencia.Value, FimVigencia = dto.FimVigencia };
        repository.Adicionar(item);
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return ResultadoDto<Guid>.RetornaSucesso(item.IdTarifaEnergia);
    }

    private static TarifaEnergiaDto Mapear(TarifaEnergia x) => new() { IdTarifaEnergia = x.IdTarifaEnergia, ValorKwh = x.ValorKwh, InicioVigencia = x.InicioVigencia, FimVigencia = x.FimVigencia };
}
