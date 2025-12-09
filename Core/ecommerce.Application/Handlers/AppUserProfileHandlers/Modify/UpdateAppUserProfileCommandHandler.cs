using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Commands;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserProfileHandlers.Modify
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, AppUserProfileResult>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly IMapper _mapper;

        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository appUserProfileRepository, IMapper mapper)
        {
            _appUserProfileRepository = appUserProfileRepository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _appUserProfileRepository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                throw new KeyNotFoundException($"AppUserProfile with Id {request.Id} not found.");
            }

            _mapper.Map(request, appUserProfile);
            appUserProfile.UpdatedDate = DateTime.Now;
            appUserProfile.Status = DataStatus.Updated;

            await _appUserProfileRepository.UpdateAsync(appUserProfile);
            await _appUserProfileRepository.SaveChangesAsync();

            return _mapper.Map<AppUserProfileResult>(appUserProfile);
        }
    }
}

