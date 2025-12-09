using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Queries;
using ecommerce.Application.DTOs.AppUserDTOs.Results;
using ecommerce.Concract.Repositories;

namespace ecommerce.Application.Handlers.AppUserHandlers.Read
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, AppUserResult?>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetAppUserByIdQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<AppUserResult?> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetByIdAsync(request.Id);

            if (appUser == null)
            {
                return null;
            }

            return _mapper.Map<AppUserResult>(appUser);
        }
    }
}

