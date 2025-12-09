using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Commands;
using ecommerce.Application.DTOs.ShipperDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.ShipperHandlers.Modify
{
    public class CreateShipperCommandHandler : IRequestHandler<CreateShipperCommand, ShipperResult>
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public CreateShipperCommandHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<ShipperResult> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
        {
            var shipper = _mapper.Map<Shipper>(request);
            shipper.Status = DataStatus.Inserted;
            shipper.CreatedDate = DateTime.Now;

            var createdShipper = await _shipperRepository.AddAsync(shipper);
            await _shipperRepository.SaveChangesAsync();

            return _mapper.Map<ShipperResult>(createdShipper);
        }
    }
}

