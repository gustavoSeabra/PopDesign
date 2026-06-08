namespace PopDesing.Domain.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task<int> SalvarMudancasAsync(CancellationToken cancellationToken = default);
    void Adicionar(TEntity entitidade);
    void Atualizar(TEntity entitidade);
    void Remover(TEntity entitidade);
    void DesanexaEntidade(TEntity entitidade);
}
