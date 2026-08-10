using PopLume.Application.Dtos;

namespace PopLume.Application.Services.Interfaces;

public interface ITarifaEnergiaService
{
    Task<ResultadoDto<IEnumerable<TarifaEnergiaDto>>> ObterTodasAsync(CancellationToken cancellationToken = default);
    Task<ResultadoDto<TarifaEnergiaDto?>> ObterVigenteAsync(CancellationToken cancellationToken = default);
    Task<ResultadoDto<Guid>> AdicionarAsync(CreateTarifaEnergiaDto dto, CancellationToken cancellationToken = default);
}
