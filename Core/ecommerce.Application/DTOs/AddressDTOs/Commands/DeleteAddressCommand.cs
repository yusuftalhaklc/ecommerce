using MediatR;

namespace ecommerce.Application.DTOs.AddressDTOs.Commands
{
    public class DeleteAddressCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

