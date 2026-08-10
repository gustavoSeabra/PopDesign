using Microsoft.EntityFrameworkCore;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Infrastructure.DataProvider.Context;

namespace PopLume.Infrastructure.Repositories;

public class CustoMaoDeObraRepository(PopLumeDbContext dbContext) : BaseRepository<CustoMaoDeObra>(dbContext), ICustoMaoDeObraRepository
{
    public async Task<IEnumerable<CustoMaoDeObra>> ObterTodosAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<CustoMaoDeObra>().AsNoTracking().OrderByDescending(x => x.InicioVigencia).ToListAsync(cancellationToken);

    public async Task<CustoMaoDeObra?> ObterVigenteAsync(DateOnly data, CancellationToken cancellationToken = default) =>
        await dbContext.Set<CustoMaoDeObra>().AsNoTracking()
            .FirstOrDefaultAsync(x => x.InicioVigencia <= data && (!x.FimVigencia.HasValue || x.FimVigencia >= data), cancellationToken);

    public Task<bool> ExisteSobreposicaoAsync(DateOnly inicio, DateOnly? fim, Guid? ignorarId = null, CancellationToken cancellationToken = default) =>
        dbContext.Set<CustoMaoDeObra>().AnyAsync(x =>
            (!ignorarId.HasValue || x.IdCustoMaoDeObra != ignorarId.Value) &&
            (!x.FimVigencia.HasValue || x.FimVigencia >= inicio) &&
            (!fim.HasValue || x.InicioVigencia <= fim.Value), cancellationToken);
}
