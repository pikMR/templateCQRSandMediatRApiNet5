namespace Catalog.API.Infrastructure
{
    using Catalog.API.Model;
    using Microsoft.EntityFrameworkCore;
    
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
    
        }

        public DbSet<Products> Products { get; set; }
        
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(build => {
                build.HasKey(_ => _.ProductId);
            });
        }
    }
}