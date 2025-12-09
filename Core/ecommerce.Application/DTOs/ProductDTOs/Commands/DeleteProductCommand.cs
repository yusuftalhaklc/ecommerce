using MediatR;

namespace ecommerce.Application.DTOs.ProductDTOs.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

