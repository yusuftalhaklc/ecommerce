using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Results;

namespace ecommerce.Application.DTOs.AppUserDTOs.Commands
{
    public class UpdateAppUserCommand : IRequest<AppUserResult>
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

