using System;
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
    public sealed class EditProductCommandHandler : ICommandHandler<EditProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly IMediator _mediator;

        private readonly INotificationFactory _notificationFactory;

        private readonly IMapper _mapper;

        public async Task<EditProductCommand> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            new Validator<Product>(product)
                .Add(new AllProductFieldsAreRequiredRule(() => _notificationFactory.Get("PRO-001")))
                .Run();

            if (product.IsValid)
            {
                var found = await _repository.FindAsync(product.Id);
                if (found is null)
                    return request;

                if (found.AddedBy.Id != request.User)
                    return HandleNoPermission(request);

                await _mediator.Publish(new ProductEditedEvent(found.AddedBy, found, product));
                found.Update(product);
                _repository.Edit(found);
                await _repository.SaveAsync();
            }
            else
            {
                request.AddNotification(product.Notifications);
            }

            return request;
        }

        public EditProductCommand HandleNoPermission(EditProductCommand request)
        {
            request.AddNotification(_notificationFactory.Get("USE-008"));
            return request;
        }

        public EditProductCommandHandler(IRepository<Product> repository, IMediator mediator, INotificationFactory notificationFactory, IMapper mapper)
            => (_mediator, _repository, _notificationFactory, _mapper) = (mediator, repository, notificationFactory, mapper);
    }
}