using MediatR;

namespace ecommerce.Application.DTOs.ShipperDTOs.Commands
{
    public class DeleteShipperCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

