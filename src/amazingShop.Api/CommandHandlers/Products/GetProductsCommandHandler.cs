using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Api.Commands.Products;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using amazingShop.Domain.Core.Commands;
using AutoMapper;
using amazingShop.Api.Dtos;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class GetProductsCommandHandler : ICommandHandler<GetProductsCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly INotificationFactory _notificationFactory;

        private readonly IMapper _mapper;

        public async Task<GetProductsCommand> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            request.Result = await _repository.GetAsync(
                skip: request.Skip,
                take: request.Take,
                predicate: x => request.Filter == null
                   || (((request.Filter.PriceStart == null || request.Filter.PriceStart.Value <= x.Price) && (request.Filter.PriceEnd == null || request.Filter.PriceEnd.Value >= x.Price))
                        && (request.Filter.UserId == null || request.Filter.UserId.Value == x.AddedBy.Id)),
                selector: p => _mapper.Map<ProductDto>(p));

            request.Total = await _repository.CountAsync();
            return request;
        }

        public GetProductsCommandHandler(IRepository<Product> repository, INotificationFactory notificationFactory, IMapper mapper)
            => (_repository, _notificationFactory, _mapper) = (repository, notificationFactory, mapper);
    }
}