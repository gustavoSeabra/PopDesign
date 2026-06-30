namespace PopDesign.Domain.Entities;

public class Marketplace
{
    public Guid IdMarketplace { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string LinkLoja { get; set; } = string.Empty;

    public virtual ICollection<TaxasMarketplace> TaxasMarketplace { get; set; } = new List<TaxasMarketplace>();
}
