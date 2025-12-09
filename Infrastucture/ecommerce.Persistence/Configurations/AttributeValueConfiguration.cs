using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Persistence.Configurations
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder.HasKey(av => av.Id);

            builder.Property(av => av.EntityId)
                .IsRequired();

            builder.Property(av => av.Value)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(av => av.EntityType)
                .WithMany(et => et.AttributeValues)
                .HasForeignKey(av => av.EntityTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(av => av.Attribute)
                .WithMany(a => a.Values)
                .HasForeignKey(av => av.AttributeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(av => new { av.EntityTypeId, av.EntityId, av.AttributeId })
                .IsUnique();

            builder.HasIndex(av => new { av.EntityTypeId, av.EntityId });
        }
    }
}

