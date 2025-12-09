using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AttributeHandlers.Modify
{
    public class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand, bool>
    {
        private readonly IAttributeRepository _attributeRepository;

        public DeleteAttributeCommandHandler(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        public async Task<bool> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.GetByIdAsync(request.Id);

            if (attribute == null)
            {
                return false;
            }

            attribute.DeletedDate = DateTime.Now;
            attribute.Status = DataStatus.Deleted;

            await _attributeRepository.UpdateAsync(attribute);
            await _attributeRepository.SaveChangesAsync();

            return true;
        }
    }
}

