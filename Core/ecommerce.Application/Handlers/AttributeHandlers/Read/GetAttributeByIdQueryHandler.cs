using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Queries;
using ecommerce.Application.DTOs.AttributeDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AttributeHandlers.Read
{
    public class GetAttributeByIdQueryHandler : IRequestHandler<GetAttributeByIdQuery, AttributeResult?>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAttributeByIdQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }

        public async Task<AttributeResult?> Handle(GetAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                return null;
            }

            return _mapper.Map<AttributeResult>(attribute);
        }
    }
}

