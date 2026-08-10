using PopLume.Domain.Entities;

namespace PopLume.Domain.Repositories;

public interface IFichaPrecificacaoRepository : IRepository<FichaPrecificacao>
{
    Task<IEnumerable<FichaPrecificacao>> ObterPorProdutoAsync(Guid idProduto, CancellationToken cancellationToken = default);
    Task<FichaPrecificacao?> ObterPorIdAsync(Guid idProduto, Guid idFicha, CancellationToken cancellationToken = default);
}
