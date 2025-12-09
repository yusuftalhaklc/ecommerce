using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Queries;
using ecommerce.Application.DTOs.AddressDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AddressHandlers.Read
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressResult?>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressResult?> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);

            if (address == null)
            {
                return null;
            }

            return _mapper.Map<AddressResult>(address);
        }
    }
}

