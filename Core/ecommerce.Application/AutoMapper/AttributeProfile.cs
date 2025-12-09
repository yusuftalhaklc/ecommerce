using AutoMapper;
using ecommerce.Application.DTOs.AttributeDTOs.Commands;
using ecommerce.Application.DTOs.AttributeDTOs.Results;
using Attribute = ecommerce.Domain.Models.Attribute;

namespace ecommerce.Application.AutoMapper
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<Attribute, AttributeResult>();

            CreateMap<CreateAttributeCommand, Attribute>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Values, opt => opt.Ignore());

            CreateMap<UpdateAttributeCommand, Attribute>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Values, opt => opt.Ignore());
        }
    }
}

