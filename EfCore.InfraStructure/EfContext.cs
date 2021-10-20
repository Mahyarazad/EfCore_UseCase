using EfCore.Domain.CategoryAgg;
using EfCore.Domain.ProductAgg;
using EfCore.InfraStructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EfCore.InfraStructure
{
    public class EfContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public EfContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
