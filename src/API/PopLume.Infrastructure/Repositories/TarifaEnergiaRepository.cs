using Microsoft.EntityFrameworkCore;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Infrastructure.DataProvider.Context;

namespace PopLume.Infrastructure.Repositories;

public class TarifaEnergiaRepository(PopLumeDbContext dbContext) : BaseRepository<TarifaEnergia>(dbContext), ITarifaEnergiaRepository
{
    public async Task<IEnumerable<TarifaEnergia>> ObterTodasAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<TarifaEnergia>().AsNoTracking().OrderByDescending(x => x.InicioVigencia).ToListAsync(cancellationToken);

    public async Task<TarifaEnergia?> ObterVigenteAsync(DateOnly data, CancellationToken cancellationToken = default) =>
        await dbContext.Set<TarifaEnergia>().AsNoTracking()
            .FirstOrDefaultAsync(x => x.InicioVigencia <= data && (!x.FimVigencia.HasValue || x.FimVigencia >= data), cancellationToken);

    public Task<bool> ExisteSobreposicaoAsync(DateOnly inicio, DateOnly? fim, Guid? ignorarId = null, CancellationToken cancellationToken = default) =>
        dbContext.Set<TarifaEnergia>().AnyAsync(x =>
            (!ignorarId.HasValue || x.IdTarifaEnergia != ignorarId.Value) &&
            (!x.FimVigencia.HasValue || x.FimVigencia >= inicio) &&
            (!fim.HasValue || x.InicioVigencia <= fim.Value), cancellationToken);
}
