using System;
using System.Threading;
using System.Threading.Tasks;
using amazingShop.Application.Commands.Products;
using amazingShop.Application.Dtos;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using MediatR;

namespace amazingShop.Application.CommandHandlers.Products
{
    public sealed class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, GetProductsCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly Func<Product, ProductDto> _mapper;

        public GetProductsCommandHandler(IRepository<Product> repository, Func<Product, ProductDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductsCommand> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            request.Result = await _repository.GetAsync(request.Skip, request.Take, p => _mapper.Invoke(p));
            request.Total = await _repository.CountAsync();
            return request;
        }
    }
}