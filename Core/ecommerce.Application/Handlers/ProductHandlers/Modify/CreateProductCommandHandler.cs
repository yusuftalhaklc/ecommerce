using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Commands;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.ProductHandlers.Modify
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IAttributeValueRepository attributeValueRepository,
            IEntityTypeRepository entityTypeRepository,
            IAttributeRepository attributeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _attributeValueRepository = attributeValueRepository;
            _entityTypeRepository = entityTypeRepository;
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<ProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            product.Status = DataStatus.Inserted;
            product.CreatedDate = DateTime.Now;

            var createdProduct = await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            var allEntityTypes = await _entityTypeRepository.GetAllAsync();
            var productEntityType = allEntityTypes.FirstOrDefault(et => et.Name == nameof(Product));
            
            if (productEntityType == null)
            {
                productEntityType = await _entityTypeRepository.AddAsync(new EntityType { Name = nameof(Product), Status = DataStatus.Inserted, CreatedDate = DateTime.Now });
                await _entityTypeRepository.SaveChangesAsync();
            }

            if (request.AttributeValues?.Any() == true)
            {
                foreach (var attrValue in request.AttributeValues)
                {
                    var attributeValue = new AttributeValue
                    {
                        EntityTypeId = productEntityType.Id,
                        EntityId = createdProduct.Id,
                        AttributeId = attrValue.AttributeId,
                        Value = attrValue.Value,
                        Status = DataStatus.Inserted,
                        CreatedDate = DateTime.Now
                    };

                    await _attributeValueRepository.AddAsync(attributeValue);
                }
                await _attributeValueRepository.SaveChangesAsync();
            }

            var result = _mapper.Map<ProductResult>(createdProduct);

            // Add AttributeValues to result
            if (request.AttributeValues?.Any() == true)
            {
                var allAttributes = await _attributeRepository.GetAllAsync();
                
                result.AttributeValues = request.AttributeValues.Select(av => new ecommerce.Application.DTOs.ProductDTOs.ProductAttributeValueDto
                {
                    AttributeId = av.AttributeId,
                    AttributeName = allAttributes.FirstOrDefault(a => a.Id == av.AttributeId)?.Name ?? av.AttributeName,
                    Value = av.Value
                }).ToList();
            }

            return result;
        }
    }
}
