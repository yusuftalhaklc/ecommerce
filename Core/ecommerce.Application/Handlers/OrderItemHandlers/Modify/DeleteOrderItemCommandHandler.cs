using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.OrderItemHandlers.Modify
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, bool>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<bool> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.Id);

            if (orderItem == null)
            {
                return false;
            }

            orderItem.DeletedDate = DateTime.Now;
            orderItem.Status = DataStatus.Deleted;

            await _orderItemRepository.UpdateAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();

            return true;
        }
    }
}

