using eShopSolutionData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolutionData.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(t => new { t.CategoryId, t.ProductId });
            builder.HasOne(t => t.Product)
                .WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.ProductId);
            builder.HasOne(t => t.Category)
                .WithMany(x => x.ProductInCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}