using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Persistence.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(pa => pa.Values)
                .WithOne(pav => pav.Attribute)
                .HasForeignKey(pav => pav.ProductAttributeId);
        }
    }
}

