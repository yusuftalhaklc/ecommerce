using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Commands;
using ecommerce.Application.DTOs.OrderDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.OrderHandlers.Modify
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with Id {request.Id} not found.");
            }

            _mapper.Map(request, order);
            order.UpdatedDate = DateTime.Now;
            order.Status = DataStatus.Updated;

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            return _mapper.Map<OrderResult>(order);
        }
    }
}

