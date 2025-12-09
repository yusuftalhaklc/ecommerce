using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AddressHandlers.Modify
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync(request.Id);

            if (address == null)
            {
                return false;
            }

            address.DeletedDate = DateTime.Now;
            address.Status = DataStatus.Deleted;

            await _addressRepository.UpdateAsync(address);
            await _addressRepository.SaveChangesAsync();

            return true;
        }
    }
}

