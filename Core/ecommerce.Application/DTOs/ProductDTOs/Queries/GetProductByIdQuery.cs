using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Results;

namespace ecommerce.Application.DTOs.ProductDTOs.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResult?>
    {
        public int Id { get; set; }
    }
}

