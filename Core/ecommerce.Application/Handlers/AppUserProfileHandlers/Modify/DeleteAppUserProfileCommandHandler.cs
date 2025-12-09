using MediatR;
using ecommerce.Application.DTOs.AppUserProfileDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserProfileHandlers.Modify
{
    public class DeleteAppUserProfileCommandHandler : IRequestHandler<DeleteAppUserProfileCommand, bool>
    {
        private readonly IAppUserProfileRepository _appUserProfileRepository;

        public DeleteAppUserProfileCommandHandler(IAppUserProfileRepository appUserProfileRepository)
        {
            _appUserProfileRepository = appUserProfileRepository;
        }

        public async Task<bool> Handle(DeleteAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _appUserProfileRepository.GetByIdAsync(request.Id);

            if (appUserProfile == null)
            {
                return false;
            }

            appUserProfile.DeletedDate = DateTime.Now;
            appUserProfile.Status = DataStatus.Deleted;

            await _appUserProfileRepository.UpdateAsync(appUserProfile);
            await _appUserProfileRepository.SaveChangesAsync();

            return true;
        }
    }
}

