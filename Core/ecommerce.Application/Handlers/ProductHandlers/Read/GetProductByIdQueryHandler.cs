using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Queries;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ProductHandlers.Read
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResult?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResult?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductResult>(product);
        }
    }
}
