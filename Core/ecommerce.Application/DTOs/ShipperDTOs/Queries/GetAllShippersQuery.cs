using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Results;

namespace ecommerce.Application.DTOs.ShipperDTOs.Queries
{
    public class GetAllShippersQuery : IRequest<ShipperListResult>
    {
    }
}

