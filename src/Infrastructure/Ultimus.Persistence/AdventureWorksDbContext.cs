using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CustomerAddress> CustomerAddress  { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory{ get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdventureWorksDbContext).Assembly);
            modelBuilder.HasDefaultSchema("SalesLT");
        }
    }
}
