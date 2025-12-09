using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AttributeValueHandlers.Modify
{
    public class DeleteAttributeValueCommandHandler : IRequestHandler<DeleteAttributeValueCommand, bool>
    {
        private readonly IAttributeValueRepository _attributeValueRepository;

        public DeleteAttributeValueCommandHandler(IAttributeValueRepository attributeValueRepository)
        {
            _attributeValueRepository = attributeValueRepository;
        }

        public async Task<bool> Handle(DeleteAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = await _attributeValueRepository.GetByIdAsync(request.Id);

            if (attributeValue == null)
            {
                return false;
            }

            attributeValue.DeletedDate = DateTime.Now;
            attributeValue.Status = DataStatus.Deleted;

            await _attributeValueRepository.UpdateAsync(attributeValue);
            await _attributeValueRepository.SaveChangesAsync();

            return true;
        }
    }
}

