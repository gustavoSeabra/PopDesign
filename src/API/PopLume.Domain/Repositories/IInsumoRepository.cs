using PopLume.Domain.Entities;

namespace PopLume.Domain.Repositories;

public interface IInsumoRepository : IRepository<Insumo>
{
    Task<IEnumerable<Insumo>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task<Insumo?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Insumo>> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default);
}
