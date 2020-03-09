using System;
using System.Threading.Tasks;
using amazingShop.Application.Dtos;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Commands.Products;
using MediatR;
using System.Threading;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Application.CommandHandlers.Products
{
    public sealed class GetProductCommandHandler : IRequestHandler<GetProductCommand, GetProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly INotificationFactory _notificationFactory;

        private readonly Func<Product, ProductDto> _mapper;

        public async Task<GetProductCommand> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindAsync(request.Id);
            request.Result = result is null ? null : _mapper.Invoke(result);
            return request;
        }

        public GetProductCommandHandler(IRepository<Product> repository, INotificationFactory notificationFactory, Func<Product, ProductDto> mapper)
            => (_repository, _notificationFactory, _mapper) = (repository, notificationFactory, mapper);
    }
}