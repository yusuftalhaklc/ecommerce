using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.EntityTypeHandlers.Modify
{
    public class DeleteEntityTypeCommandHandler : IRequestHandler<DeleteEntityTypeCommand, bool>
    {
        private readonly IEntityTypeRepository _entityTypeRepository;

        public DeleteEntityTypeCommandHandler(IEntityTypeRepository entityTypeRepository)
        {
            _entityTypeRepository = entityTypeRepository;
        }

        public async Task<bool> Handle(DeleteEntityTypeCommand request, CancellationToken cancellationToken)
        {
            var entityType = await _entityTypeRepository.GetByIdAsync(request.Id);

            if (entityType == null)
            {
                return false;
            }

            entityType.DeletedDate = DateTime.Now;
            entityType.Status = DataStatus.Deleted;

            await _entityTypeRepository.UpdateAsync(entityType);
            await _entityTypeRepository.SaveChangesAsync();

            return true;
        }
    }
}

