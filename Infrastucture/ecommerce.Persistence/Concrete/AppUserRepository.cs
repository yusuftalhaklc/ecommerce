using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Persistence.Context;

namespace ecommerce.Persistence.Concrete
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}

