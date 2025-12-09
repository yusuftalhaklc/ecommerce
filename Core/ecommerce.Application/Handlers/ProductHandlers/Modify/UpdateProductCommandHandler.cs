using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.ProductDTOs.Commands;
using ecommerce.Application.DTOs.ProductDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.ProductHandlers.Modify
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IAttributeValueRepository attributeValueRepository,
            IEntityTypeRepository entityTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _attributeValueRepository = attributeValueRepository;
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<ProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            _mapper.Map(request, product);
            product.UpdatedDate = DateTime.Now;
            product.Status = DataStatus.Updated;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();

            // Get Product EntityType
            var allEntityTypes = await _entityTypeRepository.GetAllAsync();
            var productEntityType = allEntityTypes.FirstOrDefault(et => et.Name == "Product");

            if (productEntityType != null)
            {
                // Delete existing AttributeValues
                var existingAttributeValues = (await _attributeValueRepository.GetAllAsync())
                    .Where(av => av.EntityTypeId == productEntityType.Id && av.EntityId == product.Id);

                foreach (var existingValue in existingAttributeValues)
                {
                    await _attributeValueRepository.DeleteAsync(existingValue);
                }
                await _attributeValueRepository.SaveChangesAsync();

                // Add new AttributeValues
                if (request.AttributeValues?.Any() == true)
                {
                    foreach (var attrValue in request.AttributeValues)
                    {
                        var attributeValue = new ecommerce.Domain.Models.AttributeValue
                        {
                            EntityTypeId = productEntityType.Id,
                            EntityId = product.Id,
                            AttributeId = attrValue.AttributeId,
                            Value = attrValue.Value,
                            Status = DataStatus.Inserted,
                            CreatedDate = DateTime.Now
                        };

                        await _attributeValueRepository.AddAsync(attributeValue);
                    }
                    await _attributeValueRepository.SaveChangesAsync();
                }
            }

            return _mapper.Map<ProductResult>(product);
        }
    }
}
