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
using MediatR;

namespace amazingShop.Api.CommandHandlers.Users
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IMediator _mediator;

        private readonly IAuthenticationService _authService;

        private readonly Func<RegisterUserCommand, User> _mapper;

        private readonly INotificationFactory _notificationFactory;

        private readonly IRepository<User> _repository;

        public async Task<RegisterUserCommand> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            new Validator<RegisterUserCommand>(request)
                .Add(new AllUserInFieldsAreRequired(() => _notificationFactory.Get("USE-001")))
                .Run();

            if (!request.IsValid)
                return request;

            var user = _authService.Register(request.Name ?? string.Empty, request.Email ?? string.Empty, request.Password ?? string.Empty);

            await _repository.AddAsync(user);
            await _repository.SaveAsync();

            return request;
        }

        public RegisterUserCommandHandler(IMediator mediator, IAuthenticationService authService, Func<RegisterUserCommand, User> mapper, INotificationFactory notificationFactory, IRepository<User> repository)
        {
            _mediator = mediator;
            _authService = authService;
            _mapper = mapper;
            _notificationFactory = notificationFactory;
            _repository = repository;
        }
    }
}