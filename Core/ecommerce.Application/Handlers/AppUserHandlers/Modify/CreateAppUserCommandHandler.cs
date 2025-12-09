using AutoMapper;
using MediatR;
using ecommerce.Application.DTOs.AppUserDTOs.Commands;
using ecommerce.Application.DTOs.AppUserDTOs.Results;
using ecommerce.Concract.Repositories;
using ecommerce.Domain.Models;
using ecommerce.Domain.Enums;

namespace ecommerce.Application.Handlers.AppUserHandlers.Modify
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, AppUserResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<AppUserResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request);
            appUser.Status = DataStatus.Inserted;
            appUser.CreatedDate = DateTime.Now;

            var createdAppUser = await _appUserRepository.AddAsync(appUser);
            await _appUserRepository.SaveChangesAsync();

            return _mapper.Map<AppUserResult>(createdAppUser);
        }
    }
}

