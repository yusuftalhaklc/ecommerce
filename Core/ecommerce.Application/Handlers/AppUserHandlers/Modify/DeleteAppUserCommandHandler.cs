using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Commands;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserHandlers.Modify
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, bool>
    {
        private readonly IAppUserRepository _appUserRepository;

        public DeleteAppUserCommandHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<bool> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetByIdAsync(request.Id);

            if (appUser == null)
            {
                return false;
            }

            appUser.DeletedDate = DateTime.Now;
            appUser.Status = DataStatus.Deleted;

            await _appUserRepository.UpdateAsync(appUser);
            await _appUserRepository.SaveChangesAsync();

            return true;
        }
    }
}

