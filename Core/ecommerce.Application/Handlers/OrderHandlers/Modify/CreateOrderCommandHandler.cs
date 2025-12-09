using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Commands;
using ecommerce.Application.DTOs.OrderDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.OrderHandlers.Modify
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.Status = DataStatus.Inserted;
            order.CreatedDate = DateTime.Now;
            order.CreatedAt = DateTime.Now;

            var createdOrder = await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return _mapper.Map<OrderResult>(createdOrder);
        }
    }
}

