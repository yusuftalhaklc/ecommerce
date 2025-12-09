using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Commands;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.OrderItemHandlers.Modify
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, OrderItemResult>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResult> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = _mapper.Map<OrderItem>(request);
            orderItem.Status = DataStatus.Inserted;
            orderItem.CreatedDate = DateTime.Now;

            var createdOrderItem = await _orderItemRepository.AddAsync(orderItem);
            await _orderItemRepository.SaveChangesAsync();

            return _mapper.Map<OrderItemResult>(createdOrderItem);
        }
    }
}

