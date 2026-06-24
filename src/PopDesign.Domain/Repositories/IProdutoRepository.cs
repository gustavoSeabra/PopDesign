using PopDesign.Domain.Entities;

namespace PopDesign.Domain.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterTodosProdutosAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Produto>> ObterProdutosPorNomeAsync(string nome, CancellationToken cancellationToken = default);
    Task<Produto?> ObterProdutosPorIdAsync(Guid idProduto, CancellationToken cancellationToken = default);
}
