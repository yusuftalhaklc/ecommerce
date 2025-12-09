using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Commands;
using ecommerce.Application.DTOs.AppUserDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserHandlers.Modify
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, AppUserResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<AppUserResult> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetByIdAsync(request.Id);

            if (appUser == null)
            {
                throw new KeyNotFoundException($"AppUser with Id {request.Id} not found.");
            }

            _mapper.Map(request, appUser);
            appUser.UpdatedDate = DateTime.Now;
            appUser.Status = DataStatus.Updated;

            await _appUserRepository.UpdateAsync(appUser);
            await _appUserRepository.SaveChangesAsync();

            return _mapper.Map<AppUserResult>(appUser);
        }
    }
}

