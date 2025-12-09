using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.AppUserProfileDTOs.Commands
{
    public class CreateAppUserProfileCommand : IRequest<AppUserProfileResult>
    {
        public int AppUserId { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

