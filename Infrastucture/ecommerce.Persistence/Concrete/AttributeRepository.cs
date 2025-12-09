using ecommerce.Concract.Repositories;
using ecommerce.Persistence.Context;
using Attribute = ecommerce.Domain.Models.Attribute;

namespace ecommerce.Persistence.Concrete
{
    public class AttributeRepository : BaseRepository<Attribute>, IAttributeRepository
    {
        public AttributeRepository(AppDbContext context) : base(context)
        {
        }
    }
}

