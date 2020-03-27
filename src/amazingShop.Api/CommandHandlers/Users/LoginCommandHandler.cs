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

namespace amazingShop.Api.CommandHandlers.Users
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IMapper _mapper;

        private readonly IRepository<User> _repository;

        private readonly IAuthenticationService _authService;

        private readonly INotificationFactory _notificationFactory;

        public async Task<LoginCommand> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            new Validator<LoginCommand>(request)
                .Add(new UsernameAndPasswordRequiredRule(() => _notificationFactory.Get("USE-002")))
                .Run();

            if (!request.IsValid)
                return request;

            var user = await _repository.FindAsync(x => x.Name == request.Name);

            if (user is null)
            {
                request.AddNotification(_notificationFactory.Get("USE-006"));
                return request;
            }

            var token = _authService.Login(user, request.Password ?? default!);

            if (string.IsNullOrEmpty(token))
            {
                request.AddNotification(_notificationFactory.Get("USE-007"));
                return request;
            }

            request.Result = token;

            return request;
        }

        public LoginCommandHandler(IMapper mapper, IRepository<User> repository, IAuthenticationService authService, INotificationFactory notificationFactory)
        {
            _mapper = mapper;
            _repository = repository;
            _authService = authService;
            _notificationFactory = notificationFactory;
        }
    }
}