using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;

namespace ecommerce.Application.DTOs.OrderItemDTOs.Queries
{
    public class GetOrderItemByIdQuery : IRequest<OrderItemResult?>
    {
        public int Id { get; set; }
    }
}

