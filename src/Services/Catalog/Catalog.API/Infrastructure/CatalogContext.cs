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
                entity.Property(_=>_.Price).HasColumnType("decimal(18,2)");
                entity.Property(_=>_.Description);
            });

             modelBuilder.Entity<Products>().HasData(new Products
            {
                ProductId = 1,
                Name = "Mas por Mas lubricante 95",
                Manufacturer = "Daniel Lubricantes",
                Price = 100,
                Description = "Lubricante para gasoil 95 de papa Ardila"
            }, new Products
            {
                ProductId = 2,
                Name = "Mas por Mas lubricante 98",
                Manufacturer = "Daniel Lubricantes",
                Price = 200,
                Description = "Lubricante para gasoil 98 de papa Ardila"
            });
        }
    }
}