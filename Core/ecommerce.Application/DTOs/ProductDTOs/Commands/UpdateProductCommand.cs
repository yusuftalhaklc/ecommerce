using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Results;

namespace ecommerce.Application.DTOs.ProductDTOs.Commands
{
    public class UpdateProductCommand : IRequest<ProductResult>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}

