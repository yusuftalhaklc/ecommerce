using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Attribute = ecommerce.Domain.Models.Attribute;

namespace ecommerce.Persistence.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(a => a.Values)
                .WithOne(av => av.Attribute)
                .HasForeignKey(av => av.AttributeId);
        }
    }
}

