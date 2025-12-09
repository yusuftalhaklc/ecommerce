using MediatR;

namespace ecommerce.Application.DTOs.AppUserDTOs.Commands
{
    public class DeleteAppUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

