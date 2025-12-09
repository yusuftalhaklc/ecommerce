using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Queries;
using ecommerce.Application.DTOs.AttributeDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AttributeHandlers.Read
{
    public class GetAllAttributesQueryHandler : IRequestHandler<GetAllAttributesQuery, AttributeListResult>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAllAttributesQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeListResult> Handle(GetAllAttributesQuery request, CancellationToken cancellationToken)
        {
            var attributes = await _attributeRepository.GetAllAsync();
            var attributeResults = _mapper.Map<IEnumerable<AttributeResult>>(attributes);

            return new AttributeListResult
            {
                Attributes = attributeResults,
                TotalCount = attributeResults.Count()
            };
        }
    }
}

