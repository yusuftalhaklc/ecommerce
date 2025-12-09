using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.ShipperHandlers.Modify
{
    public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand, bool>
    {
        private readonly IShipperRepository _shipperRepository;

        public DeleteShipperCommandHandler(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<bool> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
        {
            var shipper = await _shipperRepository.GetByIdAsync(request.Id);

            if (shipper == null)
            {
                return false;
            }

            shipper.DeletedDate = DateTime.Now;
            shipper.Status = DataStatus.Deleted;

            await _shipperRepository.UpdateAsync(shipper);
            await _shipperRepository.SaveChangesAsync();

            return true;
        }
    }
}

