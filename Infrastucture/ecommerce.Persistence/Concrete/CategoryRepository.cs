using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Persistence.Context;

namespace ecommerce.Persistence.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}

