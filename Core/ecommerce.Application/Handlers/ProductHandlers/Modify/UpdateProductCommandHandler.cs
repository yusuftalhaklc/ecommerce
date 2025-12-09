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
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
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

            return _mapper.Map<ProductResult>(product);
        }
    }
}
