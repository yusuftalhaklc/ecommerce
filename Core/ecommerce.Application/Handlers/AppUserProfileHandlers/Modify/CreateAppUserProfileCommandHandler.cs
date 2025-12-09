using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Commands;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserProfileHandlers.Modify
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, AppUserProfileResult>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;
        private readonly IMapper _mapper;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository appUserProfileRepository, IMapper mapper)
        {
            _appUserProfileRepository = appUserProfileRepository;
            _mapper = mapper;
        }

        public async Task<AppUserProfileResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = _mapper.Map<AppUserProfile>(request);
            appUserProfile.Id = request.AppUserId; // Set Id to AppUserId for shared primary key relationship
            appUserProfile.Status = DataStatus.Inserted;
            appUserProfile.CreatedDate = DateTime.Now;

            var createdAppUserProfile = await _appUserProfileRepository.AddAsync(appUserProfile);
            await _appUserProfileRepository.SaveChangesAsync();

            return _mapper.Map<AppUserProfileResult>(createdAppUserProfile);
        }
    }
}

