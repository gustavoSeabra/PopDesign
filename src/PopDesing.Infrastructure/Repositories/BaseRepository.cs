using Microsoft.EntityFrameworkCore;
using PopDesing.Domain.Repositories;
using PopDesing.Infrastructure.DataProvider.Context;

namespace PopDesing.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly PopDesingDbContext dbContext;

    public IUnitOfWork UnitOfWork => (IUnitOfWork)dbContext;

    protected BaseRepository(PopDesingDbContext dbContext) =>
        this.dbContext = dbContext;

    public void Adicionar(T entitidade) =>
        dbContext.Set<T>().Add(entitidade);


    public void Atualizar(T entitidade) =>
        dbContext.Set<T>().Update(entitidade);

    public virtual void Remover(T entitidade) =>
        dbContext.Set<T>().Remove(entitidade);

    public void DesanexaEntidade(T entitidade) =>
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
