using PopDesign.Domain.Entities;

namespace PopDesign.Domain.Repositories;

public interface ITaxasMarketplaceRepository : IRepository<TaxasMarketplace>
{
    Task<IEnumerable<TaxasMarketplace>> ObterTaxasPorMarketplaceAsync(Guid idMarketplace, CancellationToken cancellationToken = default);
    Task<TaxasMarketplace?> ObterTaxaMarketplacePorIdAsync(Guid idTaxa, CancellationToken cancellationToken = default);
}
