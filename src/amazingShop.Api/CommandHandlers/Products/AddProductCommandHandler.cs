﻿using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Products;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Rules.Products;
using AutoMapper;
using MediatR;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IRepository<User> _repository;

        private readonly IMediator _mediator;

        private readonly INotificationFactory _notificationFactory;

        private readonly IMapper _mapper;

        public async Task<AddProductCommand> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<AddProductCommand, Product>(request);

            new Validator<Product>(product)
                .Add(new AllProductFieldsAreRequiredRule(() => _notificationFactory.Get("PRO-001")))
                .Run();

            if (product.IsValid)
            {
                var user = await _repository.FindAsync(product.AddedBy.Id);
                user?.Products.Add(product);
                await _repository.SaveAsync();
                await _mediator.Publish(new ProductAddedEvent(product));
                request.Result = product.Id;
            }
            else
            {
                request.AddNotification(product.Notifications);
            }

            return request;
        }

        public AddProductCommandHandler(IRepository<User> repository, IMediator mediator, INotificationFactory notificationFactory, IMapper mapper)
            => (_repository, _mediator, _notificationFactory, _mapper) = (repository, mediator, notificationFactory, mapper);
    }
}