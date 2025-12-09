using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Queries;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.EntityTypeHandlers.Read
{
    public class GetEntityTypeByIdQueryHandler : IRequestHandler<GetEntityTypeByIdQuery, EntityTypeResult?>
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public GetEntityTypeByIdQueryHandler(IEntityTypeRepository entityTypeRepository, IMapper mapper)
        {
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<EntityTypeResult?> Handle(GetEntityTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var entityType = await _entityTypeRepository.GetByIdAsync(request.Id);

            if (entityType == null)
            {
                return null;
            }

            return _mapper.Map<EntityTypeResult>(entityType);
        }
    }
}

