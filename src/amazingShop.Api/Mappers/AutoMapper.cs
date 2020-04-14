using amazingShop.Api.Commands.Products;
using amazingShop.Api.Commands.Users;
using amazingShop.Api.Dtos;
using amazingShop.Domain.Entities;
using AutoMapper;

namespace amazingShop.Api.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<AddProductCommand, Product>()
                .AfterMap((s, d) => d.setAddedBy(new User(s.User)));

            CreateMap<EditProductCommand, Product>()
                .AfterMap((s, d) => d.setAddedBy(new User(s.User)));

            CreateMap<DeleteProductCommand, Product>();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<RegisterUserCommand, User>()
                .ForMember(u => u.Password, x => x.AllowNull())
                .ForMember(u => u.Salt, x => x.AllowNull());

            CreateMap<User, UserDto>();

            AddValueToObjectsMapping();
            AddIgnores();
        }

        public void AddIgnores()
        {
            AddGlobalIgnore("Notifications");
            AddGlobalIgnore("_notifications");
            AddGlobalIgnore("HasNotification");
            AddGlobalIgnore("IsValid");
        }

        public void AddValueToObjectsMapping()
        {
            CreateMap<long, User>().ConvertUsing(x => new User(x));
        }
    }
}