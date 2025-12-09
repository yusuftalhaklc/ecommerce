using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Results;

namespace ecommerce.Application.DTOs.OrderDTOs.Queries
{
    public class GetAllOrdersQuery : IRequest<OrderListResult>
    {
    }
}

