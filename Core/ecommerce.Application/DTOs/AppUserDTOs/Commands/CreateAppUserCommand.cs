using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserDTOs.Commands
{
    public class CreateAppUserCommand : IRequest<AppUserResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

