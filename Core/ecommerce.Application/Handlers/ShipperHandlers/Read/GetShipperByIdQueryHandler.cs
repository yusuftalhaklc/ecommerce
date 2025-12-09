using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Queries;
using ecommerce.Application.DTOs.ShipperDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ShipperHandlers.Read
{
    public class GetShipperByIdQueryHandler : IRequestHandler<GetShipperByIdQuery, ShipperResult?>
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public GetShipperByIdQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<ShipperResult?> Handle(GetShipperByIdQuery request, CancellationToken cancellationToken)
        {
            var shipper = await _shipperRepository.GetByIdAsync(request.Id);

            if (shipper == null)
            {
                return null;
            }

            return _mapper.Map<ShipperResult>(shipper);
        }
    }
}

