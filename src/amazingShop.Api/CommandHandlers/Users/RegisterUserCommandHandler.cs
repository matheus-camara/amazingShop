using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Users;
using amazingShop.Api.Rules;
using amazingShop.Api.Services.Users;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace amazingShop.Api.CommandHandlers.Users
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IAuthenticationService _authService;

        private readonly IMapper _mapper;

        private readonly INotificationFactory _notificationFactory;

        private readonly IRepository<User> _repository;

        public async Task<RegisterUserCommand> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            new Validator<RegisterUserCommand>(request)
                .Add(new AllUserInFieldsAreRequired(() => _notificationFactory.Get("USE-001")))
                .Run();

            if (!request.IsValid)
                return request;

            var found = await SeachUserWithSameNameOrEmail(request.Name, request.Email);

            if (found is null)
            {
                var user = _authService.Register(request.Name ?? string.Empty, request.Email ?? string.Empty, request.Password ?? string.Empty);
                await _repository.AddAsync(user);
                await _repository.SaveAsync();
            }
            else
            {
                if (found?.Name == request.Name)
                    request.AddNotification(_notificationFactory.Get("USE-004"));

                if (found?.Email == request.Email)
                    request.AddNotification(_notificationFactory.Get("USE-005"));
            }

            return request;
        }

        private async Task<User?> SeachUserWithSameNameOrEmail(string? name, string? email)
            => await _repository.FindAsync(x => x.Name == name || x.Email == email);

        public RegisterUserCommandHandler(IAuthenticationService authService, IMapper mapper, INotificationFactory notificationFactory, IRepository<User> repository)
        {
            _authService = authService;
            _mapper = mapper;
            _notificationFactory = notificationFactory;
            _repository = repository;
        }
    }
}