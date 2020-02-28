using System.Threading.Tasks;
using amazingShop.Api.Dtos;
using amazingShop.Api.Mappers;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;

namespace amazingShop.Api.CommandHandlers.Products
{
    public sealed class GetProductsCommandHandler : ICommandHandler<GetProductsCommand>
    {
        private readonly IRepository<Product> _repository;

        private readonly IMapper<Product, ProductDto> _mapper;

        public GetProductsCommandHandler(IRepository<Product> repository, IMapper<Product, ProductDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductsCommand> ExecuteAsync(GetProductsCommand command)
        {
            command.Result = await _repository.GetAsync(command.Skip, command.Take, p => _mapper.Map(p));
            command.Total = await _repository.CountAsync();
            return command;
        }
    }
}