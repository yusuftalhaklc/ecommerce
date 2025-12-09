using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Results;

namespace ecommerce.Application.DTOs.ShipperDTOs.Commands
{
    public class CreateShipperCommand : IRequest<ShipperResult>
    {
        public string CompanyName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}

