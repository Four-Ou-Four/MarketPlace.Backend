using AutoMapper;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Orders.Mappers;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}
