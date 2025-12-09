using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.OrderItemDTOs.Queries;
using ecommerce.Application.DTOs.OrderItemDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.OrderItemHandlers.Read
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItemResult?>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemByIdQueryHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResult?> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.Id);

            if (orderItem == null)
            {
                return null;
            }

            return _mapper.Map<OrderItemResult>(orderItem);
        }
    }
}

