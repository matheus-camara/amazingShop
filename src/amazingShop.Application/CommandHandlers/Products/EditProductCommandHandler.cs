using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Application.Commands.Products;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Core.Validators;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Rules.Products;
using MediatR;

namespace amazingShop.Application.CommandHandlers.Products
{
    public sealed class EditProductCommandHandler : IRequestHandler<EditProductCommand, EditProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly IMediator _mediator;

        private readonly INotificationFactory _notificationFactory;

        private readonly Func<EditProductCommand?, Product> _mapper;

        public async Task<EditProductCommand> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Invoke(request);

            new Validator<Product>(product)
                .Add(new AllProductFieldsAreRequiredRule(_notificationFactory.Get("PRO-001")))
                .Run();

            if (product.IsValid)
            {
                var found = await _repository.FindAsync(product.Id);
                if (found != null)
                {
                    found.Update(product);
                    _repository.Edit(found);
                    await _repository.SaveAsync();
                    await _mediator.Publish<ProductAddedEvent>(new ProductAddedEvent(product));
                }
            }
            else
            {
                request.AddNotification(product.Notifications);
            }

            return request;
        }

        public EditProductCommandHandler(IRepository<Product> repository, IMediator mediator, INotificationFactory notificationFactory, Func<EditProductCommand?, Product> mapper)
            => (_mediator, _repository, _notificationFactory, _mapper) = (mediator, repository, notificationFactory, mapper);
    }
}