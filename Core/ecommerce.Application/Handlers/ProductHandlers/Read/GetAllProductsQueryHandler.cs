using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Queries;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ProductHandlers.Read
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var productResults = _mapper.Map<IEnumerable<ProductResult>>(products);

            return new ProductListResult
            {
                Products = productResults,
                TotalCount = productResults.Count()
            };
        }
    }
}
