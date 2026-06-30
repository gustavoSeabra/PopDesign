using Microsoft.EntityFrameworkCore;
using PopDesign.Domain.Entities;
using PopDesign.Domain.Repositories;
using PopDesign.Infrastructure.DataProvider.Context;

namespace PopDesign.Infrastructure.Repositories;

public class TaxasMarketplaceRepository : BaseRepository<TaxasMarketplace>, ITaxasMarketplaceRepository
{
    public TaxasMarketplaceRepository(PopDesignDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<TaxasMarketplace?> ObterTaxaMarketplacePorIdAsync(Guid idTaxa, CancellationToken cancellationToken = default) =>
        await dbContext.Set<TaxasMarketplace>()
            .Include(t => t.Marketplace)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.IdTaxa == idTaxa, cancellationToken);

    public async Task<IEnumerable<TaxasMarketplace>> ObterTaxasPorMarketplaceAsync(Guid idMarketplace, CancellationToken cancellationToken = default) =>
        await dbContext.Set<TaxasMarketplace>()
            .Where(t => t.IdMarketplace == idMarketplace)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}
