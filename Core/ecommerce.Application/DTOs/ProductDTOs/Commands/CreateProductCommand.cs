using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Results;

namespace ecommerce.Application.DTOs.ProductDTOs.Commands
{
    public class CreateProductCommand : IRequest<ProductResult>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}

