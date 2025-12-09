using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Persistence.Context;

namespace ecommerce.Persistence.Concrete
{
    public class AttributeValueRepository : BaseRepository<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepository(AppDbContext context) : base(context)
        {
        }
    }
}

