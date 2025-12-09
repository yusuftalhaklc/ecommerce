using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Queries;
using ecommerce.Application.DTOs.OrderDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.OrderHandlers.Read
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResult?>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResult?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order == null)
            {
                return null;
            }

            return _mapper.Map<OrderResult>(order);
        }
    }
}

