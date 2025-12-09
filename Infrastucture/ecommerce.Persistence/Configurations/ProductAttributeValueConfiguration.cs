using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Persistence.Configurations
{
    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.HasKey(pav => pav.Id);

            builder.Property(pav => pav.Value)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(pav => pav.Product)
                .WithMany(p => p.AttributeValues)
                .HasForeignKey(pav => pav.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pav => pav.Attribute)
                .WithMany(pa => pa.Values)
                .HasForeignKey(pav => pav.ProductAttributeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

