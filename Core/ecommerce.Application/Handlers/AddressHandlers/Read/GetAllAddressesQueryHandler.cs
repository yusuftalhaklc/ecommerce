using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Queries;
using ecommerce.Application.DTOs.AddressDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AddressHandlers.Read
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, AddressListResult>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAllAddressesQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressListResult> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();
            var addressResults = _mapper.Map<IEnumerable<AddressResult>>(addresses);

            return new AddressListResult
            {
                Addresses = addressResults,
                TotalCount = addressResults.Count()
            };
        }
    }
}

