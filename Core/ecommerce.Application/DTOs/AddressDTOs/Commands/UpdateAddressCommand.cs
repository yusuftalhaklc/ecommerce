using MediatR;
using ecommerce.Application.DTOs.AddressDTOs.Results;

namespace ecommerce.Application.DTOs.AddressDTOs.Commands
{
    public class UpdateAddressCommand : IRequest<AddressResult>
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Title { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
    }
}

