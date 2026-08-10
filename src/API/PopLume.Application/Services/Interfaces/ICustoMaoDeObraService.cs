using PopLume.Application.Dtos;

namespace PopLume.Application.Services.Interfaces;

public interface ICustoMaoDeObraService
{
    Task<ResultadoDto<IEnumerable<CustoMaoDeObraDto>>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task<ResultadoDto<CustoMaoDeObraDto?>> ObterVigenteAsync(CancellationToken cancellationToken = default);
    Task<ResultadoDto<Guid>> AdicionarAsync(CreateCustoMaoDeObraDto dto, CancellationToken cancellationToken = default);
}
