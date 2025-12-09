using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Commands;
using ecommerce.Application.DTOs.ShipperDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.ShipperHandlers.Modify
{
    public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, ShipperResult>
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public UpdateShipperCommandHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<ShipperResult> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
        {
            var shipper = await _shipperRepository.GetByIdAsync(request.Id);

            if (shipper == null)
            {
                throw new KeyNotFoundException($"Shipper with Id {request.Id} not found.");
            }

            _mapper.Map(request, shipper);
            shipper.UpdatedDate = DateTime.Now;
            shipper.Status = DataStatus.Updated;

            await _shipperRepository.UpdateAsync(shipper);
            await _shipperRepository.SaveChangesAsync();

            return _mapper.Map<ShipperResult>(shipper);
        }
    }
}

