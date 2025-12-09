using ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Persistence.Configurations
{
    public class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(p => p.Gender)
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .IsRequired();
        }
    }
}

