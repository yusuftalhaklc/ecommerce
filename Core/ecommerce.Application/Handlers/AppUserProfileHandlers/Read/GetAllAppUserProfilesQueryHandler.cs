using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Queries;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AppUserProfileHandlers.Read
{
    public class GetAllAppUserProfilesQueryHandler : IRequestHandler<GetAllAppUserProfilesQuery, AppUserProfileListResult>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly IMapper _mapper;

        public GetAllAppUserProfilesQueryHandler(IAppUserProfileRepository appUserProfileRepository, IMapper mapper)
        {
            _appUserProfileRepository = appUserProfileRepository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileListResult> Handle(GetAllAppUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var appUserProfiles = await _appUserProfileRepository.GetAllAsync();
            var appUserProfileResults = _mapper.Map<IEnumerable<AppUserProfileResult>>(appUserProfiles);

            return new AppUserProfileListResult
            {
                AppUserProfiles = appUserProfileResults,
                TotalCount = appUserProfileResults.Count()
            };
        }
    }
}

