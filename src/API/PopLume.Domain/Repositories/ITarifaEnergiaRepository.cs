using PopLume.Domain.Entities;

namespace PopLume.Domain.Repositories;

public interface ITarifaEnergiaRepository : IRepository<TarifaEnergia>
{
    Task<IEnumerable<TarifaEnergia>> ObterTodasAsync(CancellationToken cancellationToken = default);
    Task<TarifaEnergia?> ObterVigenteAsync(DateOnly data, CancellationToken cancellationToken = default);
    Task<bool> ExisteSobreposicaoAsync(DateOnly inicio, DateOnly? fim, Guid? ignorarId = null, CancellationToken cancellationToken = default);
}
