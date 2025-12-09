using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Queries;
using ecommerce.Application.DTOs.AppUserDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AppUserHandlers.Read
{
    public class GetAllAppUsersQueryHandler : IRequestHandler<GetAllAppUsersQuery, AppUserListResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetAllAppUsersQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<AppUserListResult> Handle(GetAllAppUsersQuery request, CancellationToken cancellationToken)
        {
            var appUsers = await _appUserRepository.GetAllAsync();
            var appUserResults = _mapper.Map<IEnumerable<AppUserResult>>(appUsers);

            return new AppUserListResult
            {
                AppUsers = appUserResults,
                TotalCount = appUserResults.Count()
            };
        }
    }
}

