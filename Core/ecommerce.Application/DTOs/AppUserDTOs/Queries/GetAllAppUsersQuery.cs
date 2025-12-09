using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserDTOs.Queries
{
    public class GetAllAppUsersQuery : IRequest<AppUserListResult>
    {
    }
}

