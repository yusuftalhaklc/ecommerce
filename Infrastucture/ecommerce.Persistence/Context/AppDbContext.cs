using ecommerce.Domain.Models;
using ecommerce.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Attribute = ecommerce.Domain.Models.Attribute;

namespace ecommerce.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeValueConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

