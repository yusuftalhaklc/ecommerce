using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Commands;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AttributeValueHandlers.Modify
{
    public class CreateAttributeValueCommandHandler : IRequestHandler<CreateAttributeValueCommand, AttributeValueResult>
    {
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IMapper _mapper;

        public CreateAttributeValueCommandHandler(IAttributeValueRepository attributeValueRepository, IMapper mapper)
        {
            _attributeValueRepository = attributeValueRepository;
            _mapper = mapper;
        }

        public async Task<AttributeValueResult> Handle(CreateAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = _mapper.Map<AttributeValue>(request);
            attributeValue.Status = DataStatus.Inserted;
            attributeValue.CreatedDate = DateTime.Now;

            var createdAttributeValue = await _attributeValueRepository.AddAsync(attributeValue);
            await _attributeValueRepository.SaveChangesAsync();

            return _mapper.Map<AttributeValueResult>(createdAttributeValue);
        }
    }
}

