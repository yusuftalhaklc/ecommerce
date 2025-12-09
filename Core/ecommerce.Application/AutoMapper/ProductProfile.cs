using AutoMapper;
using ecommerce.Application.DTOs.ProductDTOs.Commands;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Domain.Models;

namespace ecommerce.Application.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Entity -> Result
            CreateMap<Product, ProductResult>();

            // Command -> Entity
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}

