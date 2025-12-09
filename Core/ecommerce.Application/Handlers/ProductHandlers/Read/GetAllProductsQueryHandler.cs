using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs;
using ecommerce.Application.DTOs.ProductDTOs.Queries;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ProductHandlers.Read
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(
            IProductRepository productRepository,
            IAttributeValueRepository attributeValueRepository,
            IAttributeRepository attributeRepository,
            IEntityTypeRepository entityTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _attributeValueRepository = attributeValueRepository;
            _attributeRepository = attributeRepository;
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<ProductListResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var productResults = _mapper.Map<IEnumerable<ProductResult>>(products).ToList();

            // Get AttributeValues for all products
            var allEntityTypes = await _entityTypeRepository.GetAllAsync();
            var productEntityType = allEntityTypes.FirstOrDefault(et => et.Name == "Product");

            if (productEntityType != null)
            {
                var allAttributeValues = (await _attributeValueRepository.GetAllAsync())
                    .Where(av => av.EntityTypeId == productEntityType.Id)
                    .ToList();

                var allAttributes = await _attributeRepository.GetAllAsync();

                foreach (var productResult in productResults)
                {
                    var attributeValues = allAttributeValues
                        .Where(av => av.EntityId == productResult.Id)
                        .ToList();

                    productResult.AttributeValues = attributeValues.Select(av => new ProductAttributeValueDto
                    {
                        AttributeId = av.AttributeId,
                        AttributeName = allAttributes.FirstOrDefault(a => a.Id == av.AttributeId)?.Name ?? "",
                        Value = av.Value
                    }).ToList();
                }
            }

            return new ProductListResult
            {
                Products = productResults,
                TotalCount = productResults.Count
            };
        }
    }
}
