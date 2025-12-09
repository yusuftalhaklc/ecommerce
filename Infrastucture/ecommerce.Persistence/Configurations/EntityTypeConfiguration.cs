using ecommerce.Domain.Enums;
using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Persistence.Configurations
{
    public class EntityTypeConfiguration : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.HasMany(e => e.AttributeValues)
                .WithOne(av => av.EntityType)
                .HasForeignKey(av => av.EntityTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new EntityType { Id = 1, Name = EntityTypeEnum.Product, CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 2, Name = EntityTypeEnum.Category, CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 3, Name = EntityTypeEnum.AppUser, CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 4, Name = EntityTypeEnum.Order, CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 5, Name = EntityTypeEnum.Shipper, CreatedDate = new DateTime(2025, 1, 1) }
            );
        }
    }
}

