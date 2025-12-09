using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Commands;
using ecommerce.Application.DTOs.AttributeDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;
using Attribute = ecommerce.Domain.Models.Attribute;

namespace ecommerce.Application.Handlers.AttributeHandlers.Modify
{
    public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, AttributeResult>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public CreateAttributeCommandHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeResult> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = _mapper.Map<Attribute>(request);
            attribute.Status = DataStatus.Inserted;
            attribute.CreatedDate = DateTime.Now;

            var createdAttribute = await _attributeRepository.AddAsync(attribute);
            await _attributeRepository.SaveChangesAsync();

            return _mapper.Map<AttributeResult>(createdAttribute);
        }
    }
}

