using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserDTOs.Queries
{
    public class GetAppUserByIdQuery : IRequest<AppUserResult?>
    {
        public int Id { get; set; }
    }
}

