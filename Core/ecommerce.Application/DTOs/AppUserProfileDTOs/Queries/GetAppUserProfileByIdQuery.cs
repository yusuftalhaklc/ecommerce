using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserProfileDTOs.Queries
{
    public class GetAppUserProfileByIdQuery : IRequest<AppUserProfileResult?>
    {
        public int Id { get; set; }
    }
}

