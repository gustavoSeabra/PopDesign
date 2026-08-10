using Microsoft.EntityFrameworkCore;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Infrastructure.DataProvider.Context;

namespace PopLume.Infrastructure.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    public ProdutoRepository(PopLumeDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Produto?> ObterProdutosPorIdAsync(Guid idProduto, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Produto>()
            .Include(p => p.Filamentos).ThenInclude(x => x.Filamento)
            .Include(p => p.Insumos).ThenInclude(x => x.Insumo)
            .Include(p => p.ComposicoesPai)
                .ThenInclude(cp => cp.ProdutoFilho)
            .FirstOrDefaultAsync(p => p.IdProduto == idProduto, cancellationToken);

    public async Task<Produto?> ObterParaPrecificacaoAsync(Guid idProduto, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Produto>()
            .Include(p => p.Equipamento)
            .Include(p => p.Filamentos).ThenInclude(x => x.Filamento)
            .Include(p => p.Insumos).ThenInclude(x => x.Insumo)
            .Include(p => p.ComposicoesPai).ThenInclude(x => x.ProdutoFilho)
            .AsTracking()
            .FirstOrDefaultAsync(p => p.IdProduto == idProduto, cancellationToken);

    public async Task<IEnumerable<ProdutoComposicao>> ObterTodasComposicoesAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<ProdutoComposicao>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<IEnumerable<Produto>> ObterProdutosPorNomeAsync(string nome, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Produto>()
            .Where(p => EF.Functions.ILike(p.Nome, CriarPadraoBusca(nome), LikeEscapeCharacter))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<Produto>> ObterTodosProdutosAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<Produto>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}
