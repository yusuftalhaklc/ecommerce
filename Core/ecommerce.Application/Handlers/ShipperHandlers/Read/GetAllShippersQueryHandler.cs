using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ShipperDTOs.Queries;
using ecommerce.Application.DTOs.ShipperDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ShipperHandlers.Read
{
    public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQuery, ShipperListResult>
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;

        public GetAllShippersQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }

        public async Task<ShipperListResult> Handle(GetAllShippersQuery request, CancellationToken cancellationToken)
        {
            var shippers = await _shipperRepository.GetAllAsync();
            var shipperResults = _mapper.Map<IEnumerable<ShipperResult>>(shippers);

            return new ShipperListResult
            {
                Shippers = shipperResults,
                TotalCount = shipperResults.Count()
            };
        }
    }
}

