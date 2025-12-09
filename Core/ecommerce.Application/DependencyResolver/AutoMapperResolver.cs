using Microsoft.Extensions.DependencyInjection;
using ecommerce.Application.AutoMapper;

namespace ecommerce.Application.DependencyResolver
{
    public static class AutoMapperResolver
    {
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderItemProfile>();
                cfg.AddProfile<AppUserProfile>();
                cfg.AddProfile<AppUserProfileProfile>();
                cfg.AddProfile<AddressProfile>();
                cfg.AddProfile<AttributeProfile>();
                cfg.AddProfile<AttributeValueProfile>();
                cfg.AddProfile<EntityTypeProfile>();
                cfg.AddProfile<ShipperProfile>();
            });
        }
    }
}

