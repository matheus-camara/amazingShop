using System.Threading.Tasks;
using amazingShop.Api.Dtos;
using amazingShop.Api.Mappers;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;

namespace amazingShop.Api.CommandHandlers.Products
{
	public sealed class GetProductCommandHandler : ICommandHandler<GetProductCommand>
	{
		private readonly IRepository<Product> _repository;

		private readonly IMapper<Product, ProductDto> _mapper;

		public GetProductCommandHandler(IRepository<Product> repository, IMapper<Product, ProductDto> mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetProductCommand> ExecuteAsync(GetProductCommand command)
		{
			command.Result = _mapper.Map(await _repository.FindAsync(command.Id));
			return command;
		}
	}
}