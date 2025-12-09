using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Results;

namespace ecommerce.Application.DTOs.OrderDTOs.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResult?>
    {
        public int Id { get; set; }
    }
}

