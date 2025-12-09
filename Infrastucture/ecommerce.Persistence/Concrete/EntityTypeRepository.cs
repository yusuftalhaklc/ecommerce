using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Persistence.Context;

namespace ecommerce.Persistence.Concrete
{
    public class EntityTypeRepository : BaseRepository<EntityType>, IEntityTypeRepository
    {
        public EntityTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}

