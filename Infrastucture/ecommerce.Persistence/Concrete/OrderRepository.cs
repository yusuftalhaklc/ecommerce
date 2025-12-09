using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Persistence.Context;

namespace ecommerce.Persistence.Concrete
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

