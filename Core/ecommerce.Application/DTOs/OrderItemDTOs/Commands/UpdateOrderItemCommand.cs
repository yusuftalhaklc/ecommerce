using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;

namespace ecommerce.Application.DTOs.OrderItemDTOs.Commands
{
    public class UpdateOrderItemCommand : IRequest<OrderItemResult>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

