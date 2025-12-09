using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Results;

namespace ecommerce.Application.DTOs.OrderDTOs.Commands
{
    public class CreateOrderCommand : IRequest<OrderResult>
    {
        public int AppUserId { get; set; }
        public int ShipperId { get; set; }
    }
}

