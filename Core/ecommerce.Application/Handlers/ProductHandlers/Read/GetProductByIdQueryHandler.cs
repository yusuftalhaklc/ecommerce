using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs;
using ecommerce.Application.DTOs.ProductDTOs.Queries;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.ProductHandlers.Read
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResult?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(
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

        public async Task<ProductResult?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            var result = _mapper.Map<ProductResult>(product);

            // Get AttributeValues
            var allEntityTypes = await _entityTypeRepository.GetAllAsync();
            var productEntityType = allEntityTypes.FirstOrDefault(et => et.Name == "Product");

            if (productEntityType != null)
            {
                var attributeValues = (await _attributeValueRepository.GetAllAsync())
                    .Where(av => av.EntityTypeId == productEntityType.Id && av.EntityId == product.Id)
                    .ToList();

                var allAttributes = await _attributeRepository.GetAllAsync();

                result.AttributeValues = attributeValues.Select(av => new ProductAttributeValueDto
                {
                    AttributeId = av.AttributeId,
                    AttributeName = allAttributes.FirstOrDefault(a => a.Id == av.AttributeId)?.Name ?? "",
                    Value = av.Value
                }).ToList();
            }

            return result;
        }
    }
}
