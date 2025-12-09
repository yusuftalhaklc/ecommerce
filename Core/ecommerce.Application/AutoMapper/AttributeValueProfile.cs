using AutoMapper;
using ecommerce.Application.DTOs.AttributeValueDTOs.Commands;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;
using ecommerce.Domain.Models;

namespace ecommerce.Application.AutoMapper
{
    public class AttributeValueProfile : Profile
    {
        public AttributeValueProfile()
        {
            CreateMap<AttributeValue, AttributeValueResult>();

            CreateMap<CreateAttributeValueCommand, AttributeValue>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.EntityType, opt => opt.Ignore())
                .ForMember(dest => dest.Attribute, opt => opt.Ignore());

            CreateMap<UpdateAttributeValueCommand, AttributeValue>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.EntityType, opt => opt.Ignore())
                .ForMember(dest => dest.Attribute, opt => opt.Ignore());
        }
    }
}

