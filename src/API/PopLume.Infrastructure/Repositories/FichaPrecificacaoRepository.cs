using Microsoft.EntityFrameworkCore;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Infrastructure.DataProvider.Context;

namespace PopLume.Infrastructure.Repositories;

public class FichaPrecificacaoRepository(PopLumeDbContext dbContext) : BaseRepository<FichaPrecificacao>(dbContext), IFichaPrecificacaoRepository
{
    public async Task<IEnumerable<FichaPrecificacao>> ObterPorProdutoAsync(Guid idProduto, CancellationToken cancellationToken = default) =>
        await dbContext.Set<FichaPrecificacao>().Include(x => x.Itens).AsNoTracking()
            .Where(x => x.IdProduto == idProduto).OrderByDescending(x => x.CalculadaEmUtc).ToListAsync(cancellationToken);

    public async Task<FichaPrecificacao?> ObterPorIdAsync(Guid idProduto, Guid idFicha, CancellationToken cancellationToken = default) =>
        await dbContext.Set<FichaPrecificacao>().Include(x => x.Itens).AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdProduto == idProduto && x.IdFichaPrecificacao == idFicha, cancellationToken);
}
