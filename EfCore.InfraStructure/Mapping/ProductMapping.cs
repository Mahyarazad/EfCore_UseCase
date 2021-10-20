
using EfCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.InfraStructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", schema: "dbo");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductDescription).HasMaxLength(500);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
