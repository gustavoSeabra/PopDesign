using Microsoft.EntityFrameworkCore;
using PopDesing.Domain.Repositories;
using PopDesing.Infrastructure.DataProvider.Context;

namespace PopDesing.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly PopDesingDbContext dbContext;

    protected BaseRepository(PopDesingDbContext dbContext) =>
        this.dbContext = dbContext;

    public void Adicionar(TEntity entitidade) =>
        dbContext.Add(entitidade);


    public void Atualizar(TEntity entitidade) =>
        dbContext.Update(entitidade);

    public void Remover(TEntity entitidade) =>
        dbContext.Remove(entitidade);


    public async Task<int> SalvarMudancasAsync(CancellationToken cancellationToken = default) =>
        await dbContext.SaveChangesAsync(cancellationToken);

    public void DesanexaEntidade(TEntity entitidade) =>
        dbContext.Entry(entitidade).State = EntityState.Detached;


    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            dbContext.Dispose();
    }
}
