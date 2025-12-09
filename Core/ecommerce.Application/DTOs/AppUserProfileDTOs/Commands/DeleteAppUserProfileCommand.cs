using MediatR;

namespace ecommerce.Application.DTOs.AppUserProfileDTOs.Commands
{
    public class DeleteAppUserProfileCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

