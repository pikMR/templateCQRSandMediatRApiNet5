namespace Catalog.API.Infrastructure
{
    using Catalog.API.Domain.Model;
    using Microsoft.EntityFrameworkCore;
    
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
    
        }

        public DbSet<Products> Products { get; set; }
        
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                  base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Products>(entity =>
      {
        entity.HasKey(_ => _.ProductId);
        entity.Property(_=>_.Name);
        entity.Property(_=>_.Manufacturer);
        entity.Property(_=>_.Price);
        entity.Property(_=>_.Description);

        //entity.Property(e => e.Name).IsRequired();
      });

            /*modelBuilder.Entity<Products>(build => {
                build.HasKey(_ => _.ProductId);
            });*/
        }
    }
}