using LayeredArchitecture.Repositories.Models;
namespace LayeredArchitecture.Repositories;

public class MRPSystemDbContext : DbContext
{
    public DbSet<PartNumber> PartNumbers{set;get;}
    public DbSet<PurchaseRequest>PurchaseRequests{set;get;}
    public DbSet<PurchaseRequestItem> PurchaseRequestItems{set;get;}
    public MRPSystemDbContext(DbContextOptions<MRPSystemDbContext>options):base(options)
    {
    }
}