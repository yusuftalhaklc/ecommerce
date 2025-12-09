using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderDTOs.Queries;
using ecommerce.Application.DTOs.OrderDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.OrderHandlers.Read
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrderListResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderListResult> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderResults = _mapper.Map<IEnumerable<OrderResult>>(orders);

            return new OrderListResult
            {
                Orders = orderResults,
                TotalCount = orderResults.Count()
            };
        }
    }
}

