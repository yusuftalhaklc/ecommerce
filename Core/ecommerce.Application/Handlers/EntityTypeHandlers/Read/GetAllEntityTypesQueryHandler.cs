using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Queries;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.EntityTypeHandlers.Read
{
    public class GetAllEntityTypesQueryHandler : IRequestHandler<GetAllEntityTypesQuery, EntityTypeListResult>
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public GetAllEntityTypesQueryHandler(IEntityTypeRepository entityTypeRepository, IMapper mapper)
        {
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<EntityTypeListResult> Handle(GetAllEntityTypesQuery request, CancellationToken cancellationToken)
        {
            var entityTypes = await _entityTypeRepository.GetAllAsync();
            var entityTypeResults = _mapper.Map<IEnumerable<EntityTypeResult>>(entityTypes);

            return new EntityTypeListResult
            {
                EntityTypes = entityTypeResults,
                TotalCount = entityTypeResults.Count()
            };
        }
    }
}

