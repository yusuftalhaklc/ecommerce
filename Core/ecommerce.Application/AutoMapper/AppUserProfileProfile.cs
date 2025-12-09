using AutoMapper;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Commands;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using AppUserProfileEntity = ecommerce.Domain.Models.AppUserProfile;

namespace ecommerce.Application.AutoMapper
{
    public class AppUserProfileProfile : Profile
    {
        public AppUserProfileProfile()
        {
            CreateMap<AppUserProfileEntity, AppUserProfileResult>();

            CreateMap<CreateAppUserProfileCommand, AppUserProfileEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.AppUser, opt => opt.Ignore());

            CreateMap<UpdateAppUserProfileCommand, AppUserProfileEntity>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.AppUser, opt => opt.Ignore());
        }
    }
}

