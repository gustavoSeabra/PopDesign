using PopLume.Domain.Entities;

namespace PopLume.Domain.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterTodosProdutosAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Produto>> ObterProdutosPorNomeAsync(string nome, CancellationToken cancellationToken = default);
    Task<Produto?> ObterProdutosPorIdAsync(Guid idProduto, CancellationToken cancellationToken = default);
    Task<Produto?> ObterParaPrecificacaoAsync(Guid idProduto, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProdutoComposicao>> ObterTodasComposicoesAsync(CancellationToken cancellationToken = default);
}
