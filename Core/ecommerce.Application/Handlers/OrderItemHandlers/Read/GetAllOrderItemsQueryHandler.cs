using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Queries;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.OrderItemHandlers.Read
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, OrderItemListResult>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetAllOrderItemsQueryHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemListResult> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            var orderItemResults = _mapper.Map<IEnumerable<OrderItemResult>>(orderItems);

            return new OrderItemListResult
            {
                OrderItems = orderItemResults,
                TotalCount = orderItemResults.Count()
            };
        }
    }
}

