using MediatR;

namespace ecommerce.Application.DTOs.OrderItemDTOs.Commands
{
    public class DeleteOrderItemCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

