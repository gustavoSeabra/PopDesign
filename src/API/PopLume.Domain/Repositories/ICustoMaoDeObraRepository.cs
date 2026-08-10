using PopLume.Domain.Entities;

namespace PopLume.Domain.Repositories;

public interface ICustoMaoDeObraRepository : IRepository<CustoMaoDeObra>
{
    Task<IEnumerable<CustoMaoDeObra>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task<CustoMaoDeObra?> ObterVigenteAsync(DateOnly data, CancellationToken cancellationToken = default);
    Task<bool> ExisteSobreposicaoAsync(DateOnly inicio, DateOnly? fim, Guid? ignorarId = null, CancellationToken cancellationToken = default);
}
