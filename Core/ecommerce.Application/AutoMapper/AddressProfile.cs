using AutoMapper;
using ecommerce.Application.DTOs.AddressDTOs.Commands;
using ecommerce.Application.DTOs.AddressDTOs.Results;
using ecommerce.Domain.Models;

namespace ecommerce.Application.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressResult>();

            CreateMap<CreateAddressCommand, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.AppUser, opt => opt.Ignore());

            CreateMap<UpdateAddressCommand, Address>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.AppUser, opt => opt.Ignore());
        }
    }
}

