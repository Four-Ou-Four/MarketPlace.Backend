using AutoMapper;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Carts.Mappers;

public class CartMapper : Profile
{
    public CartMapper()
    {
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartItem, CartItemDto>().ReverseMap();
    }
}
