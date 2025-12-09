using MediatR;

namespace ecommerce.Application.DTOs.OrderDTOs.Commands
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

