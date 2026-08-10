using PopLume.Application.Dtos;

namespace PopLume.Application.Services.Interfaces;

public interface IInsumoService
{
    Task<ResultadoDto<IEnumerable<InsumoDto>>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task<ResultadoDto<InsumoDto?>> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ResultadoDto<Guid>> AdicionarAsync(CreateInsumoDto dto, CancellationToken cancellationToken = default);
    Task<ResultadoDto<bool>> AtualizarAsync(UpdateInsumoDto dto, CancellationToken cancellationToken = default);
    Task<ResultadoDto<bool>> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
}
