using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Commands;
using ecommerce.Application.DTOs.AddressDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AddressHandlers.Modify
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, AddressResult>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);

            if (address == null)
            {
                throw new KeyNotFoundException($"Address with Id {request.Id} not found.");
            }

            _mapper.Map(request, address);
            address.UpdatedDate = DateTime.Now;
            address.Status = DataStatus.Updated;

            await _addressRepository.UpdateAsync(address);
            await _addressRepository.SaveChangesAsync();

            return _mapper.Map<AddressResult>(address);
        }
    }
}

