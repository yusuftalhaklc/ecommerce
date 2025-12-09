using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Results;

namespace ecommerce.Application.DTOs.AddressDTOs.Queries
{
    public class GetAllAddressesQuery : IRequest<AddressListResult>
    {
    }
}

