using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Commands;
using ecommerce.Application.DTOs.AddressDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AddressHandlers.Modify
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressResult>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _mapper.Map<Address>(request);
            address.Status = DataStatus.Inserted;
            address.CreatedDate = DateTime.Now;

            var createdAddress = await _addressRepository.AddAsync(address);
            await _addressRepository.SaveChangesAsync();

            return _mapper.Map<AddressResult>(createdAddress);
        }
    }
}

