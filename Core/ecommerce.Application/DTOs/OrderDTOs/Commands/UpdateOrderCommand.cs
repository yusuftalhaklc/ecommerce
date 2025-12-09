using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Results;

namespace ecommerce.Application.DTOs.OrderDTOs.Commands
{
    public class UpdateOrderCommand : IRequest<OrderResult>
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ShipperId { get; set; }
    }
}

