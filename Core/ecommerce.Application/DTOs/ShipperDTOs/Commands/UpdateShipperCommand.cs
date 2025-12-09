using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Results;

namespace ecommerce.Application.DTOs.ShipperDTOs.Commands
{
    public class UpdateShipperCommand : IRequest<ShipperResult>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}

