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
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.HasMany(e => e.AttributeValues)
                .WithOne(av => av.EntityType)
                .HasForeignKey(av => av.EntityTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new EntityType { Id = 1, Name = nameof(Address), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 2, Name = nameof(AppUser), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 3, Name = nameof(AppUserProfile), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 4, Name = nameof(Domain.Models.Attribute), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 5, Name = nameof(Category), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 6, Name = nameof(Order), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 7, Name = nameof(OrderItem), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 8, Name = nameof(Product), CreatedDate = new DateTime(2025, 1, 1) },
                new EntityType { Id = 9, Name = nameof(Shipper), CreatedDate = new DateTime(2025, 1, 1) }
            );
        }
    }
}

