using System;
using System.Threading.Tasks;
using amazingShop.Application.Dtos;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using amazingShop.Application.Commands.Products;
using MediatR;
using System.Threading;

namespace amazingShop.Application.CommandHandlers.Products
{
    public sealed class GetProductCommandHandler : IRequestHandler<GetProductCommand, GetProductCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly Func<Product, ProductDto> _mapper;

        public GetProductCommandHandler(IRepository<Product> repository, Func<Product, ProductDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductCommand> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            request.Result = _mapper.Invoke(await _repository.FindAsync(request.Id));
            return request;
        }
    }
}