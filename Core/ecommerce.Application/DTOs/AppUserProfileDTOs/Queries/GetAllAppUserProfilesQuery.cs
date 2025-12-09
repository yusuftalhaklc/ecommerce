using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserProfileDTOs.Queries
{
    public class GetAllAppUserProfilesQuery : IRequest<AppUserProfileListResult>
    {
    }
}

