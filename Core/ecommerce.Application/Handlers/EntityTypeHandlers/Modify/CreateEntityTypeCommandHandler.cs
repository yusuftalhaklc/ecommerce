using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Commands;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.EntityTypeHandlers.Modify
{
    public class CreateEntityTypeCommandHandler : IRequestHandler<CreateEntityTypeCommand, EntityTypeResult>
    {
        private readonly IEntityTypeRepository _entityTypeRepository;
        private readonly IMapper _mapper;

        public CreateEntityTypeCommandHandler(IEntityTypeRepository entityTypeRepository, IMapper mapper)
        {
            _entityTypeRepository = entityTypeRepository;
            _mapper = mapper;
        }

        public async Task<EntityTypeResult> Handle(CreateEntityTypeCommand request, CancellationToken cancellationToken)
        {
            var entityType = _mapper.Map<EntityType>(request);
            entityType.Status = DataStatus.Inserted;
            entityType.CreatedDate = DateTime.Now;

            var createdEntityType = await _entityTypeRepository.AddAsync(entityType);
            await _entityTypeRepository.SaveChangesAsync();

            return _mapper.Map<EntityTypeResult>(createdEntityType);
        }
    }
}

