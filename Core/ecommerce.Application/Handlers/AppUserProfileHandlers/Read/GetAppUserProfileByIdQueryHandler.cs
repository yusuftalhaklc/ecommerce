using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Queries;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AppUserProfileHandlers.Read
{
    public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, AppUserProfileResult?>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly IMapper _mapper;

        public GetAppUserProfileByIdQueryHandler(IAppUserProfileRepository appUserProfileRepository, IMapper mapper)
        {
            _appUserProfileRepository = appUserProfileRepository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileResult?> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _appUserProfileRepository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                return null;
            }

            return _mapper.Map<AppUserProfileResult>(appUserProfile);
        }
    }
}

