using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Commands;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AttributeValueHandlers.Modify
{
    public class UpdateAttributeValueCommandHandler : IRequestHandler<UpdateAttributeValueCommand, AttributeValueResult>
    {
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IMapper _mapper;

        public UpdateAttributeValueCommandHandler(IAttributeValueRepository attributeValueRepository, IMapper mapper)
        {
            _attributeValueRepository = attributeValueRepository;
            _mapper = mapper;
        }

        public async Task<AttributeValueResult> Handle(UpdateAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = await _attributeValueRepository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                throw new KeyNotFoundException($"AttributeValue with Id {request.Id} not found.");
            }

            _mapper.Map(request, attributeValue);
            attributeValue.UpdatedDate = DateTime.Now;
            attributeValue.Status = DataStatus.Updated;

            await _attributeValueRepository.UpdateAsync(attributeValue);
            await _attributeValueRepository.SaveChangesAsync();

            return _mapper.Map<AttributeValueResult>(attributeValue);
        }
    }
}

