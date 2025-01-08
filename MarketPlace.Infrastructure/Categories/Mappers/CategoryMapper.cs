using AutoMapper;
using MarketPlace.Application.Categories.Models;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Categories.Mappers;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
