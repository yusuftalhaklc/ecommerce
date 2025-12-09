using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Queries;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AttributeValueHandlers.Read
{
    public class GetAttributeValueByIdQueryHandler : IRequestHandler<GetAttributeValueByIdQuery, AttributeValueResult?>
    {
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IMapper _mapper;

        public GetAttributeValueByIdQueryHandler(IAttributeValueRepository attributeValueRepository, IMapper mapper)
        {
            _attributeValueRepository = attributeValueRepository;
            _mapper = mapper;
        }

        public async Task<AttributeValueResult?> Handle(GetAttributeValueByIdQuery request, CancellationToken cancellationToken)
        {
            var attributeValue = await _attributeValueRepository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                return null;
            }

            return _mapper.Map<AttributeValueResult>(attributeValue);
        }
    }
}

