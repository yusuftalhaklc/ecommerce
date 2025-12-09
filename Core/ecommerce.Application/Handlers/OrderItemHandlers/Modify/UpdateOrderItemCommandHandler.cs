using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Commands;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.OrderItemHandlers.Modify
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, OrderItemResult>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResult> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.Id);

            if (orderItem == null)
            {
                throw new KeyNotFoundException($"OrderItem with Id {request.Id} not found.");
            }

            _mapper.Map(request, orderItem);
            orderItem.UpdatedDate = DateTime.Now;
            orderItem.Status = DataStatus.Updated;

            await _orderItemRepository.UpdateAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();

            return _mapper.Map<OrderItemResult>(orderItem);
        }
    }
}

