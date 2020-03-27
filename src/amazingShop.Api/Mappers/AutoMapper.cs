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
            CreateMap<AddProductCommand, Product>();
            CreateMap<EditProductCommand, Product>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<RegisterUserCommand, User>()
                .ForMember(u => u.Password, x => x.AllowNull())
                .ForMember(u => u.Salt, x => x.AllowNull());

            CreateMap<User, UserDto>();

            AddIgnores();
        }

        public void AddIgnores()
        {
            AddGlobalIgnore("Notifications");
            AddGlobalIgnore("_notifications");
            AddGlobalIgnore("HasNotification");
            AddGlobalIgnore("IsValid");
        }
    }
}