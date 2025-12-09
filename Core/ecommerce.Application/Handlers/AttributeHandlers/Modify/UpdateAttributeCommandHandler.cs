using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Commands;
using ecommerce.Application.DTOs.AttributeDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AttributeHandlers.Modify
{
    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, AttributeResult>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public UpdateAttributeCommandHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeResult> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                throw new KeyNotFoundException($"Attribute with Id {request.Id} not found.");
            }

            _mapper.Map(request, attribute);
            attribute.UpdatedDate = DateTime.Now;
            attribute.Status = DataStatus.Updated;

            await _attributeRepository.UpdateAsync(attribute);
            await _attributeRepository.SaveChangesAsync();

            return _mapper.Map<AttributeResult>(attribute);
        }
    }
}

