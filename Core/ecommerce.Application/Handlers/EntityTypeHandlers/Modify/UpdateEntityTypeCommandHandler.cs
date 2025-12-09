using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Commands;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.EntityTypeHandlers.Modify
{
    public class UpdateEntityTypeCommandHandler : IRequestHandler<UpdateEntityTypeCommand, EntityTypeResult>
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public UpdateEntityTypeCommandHandler(IEntityTypeRepository entityTypeRepository, IMapper mapper)
        {
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<EntityTypeResult> Handle(UpdateEntityTypeCommand request, CancellationToken cancellationToken)
        {
            var entityType = await _entityTypeRepository.GetByIdAsync(request.Id);

            if (entityType == null)
            {
                throw new KeyNotFoundException($"EntityType with Id {request.Id} not found.");
            }

            _mapper.Map(request, entityType);
            entityType.UpdatedDate = DateTime.Now;
            entityType.Status = DataStatus.Updated;

            await _entityTypeRepository.UpdateAsync(entityType);
            await _entityTypeRepository.SaveChangesAsync();

            return _mapper.Map<EntityTypeResult>(entityType);
        }
    }
}

