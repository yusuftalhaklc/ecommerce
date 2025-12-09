using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Queries;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AttributeValueHandlers.Read
{
    public class GetAllAttributeValuesQueryHandler : IRequestHandler<GetAllAttributeValuesQuery, AttributeValueListResult>
    {
        private readonly IAttributeValueRepository _attributeValueRepository;
        private readonly IMapper _mapper;

        public GetAllAttributeValuesQueryHandler(IAttributeValueRepository attributeValueRepository, IMapper mapper)
        {
            _attributeValueRepository = attributeValueRepository;
            _mapper = mapper;
        }

        public async Task<AttributeValueListResult> Handle(GetAllAttributeValuesQuery request, CancellationToken cancellationToken)
        {
            var attributeValues = await _attributeValueRepository.GetAllAsync();
            var attributeValueResults = _mapper.Map<IEnumerable<AttributeValueResult>>(attributeValues);

            return new AttributeValueListResult
            {
                AttributeValues = attributeValueResults,
                TotalCount = attributeValueResults.Count()
            };
        }
    }
}

