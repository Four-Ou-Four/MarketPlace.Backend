using AutoMapper;
using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartItemUpdateCommandHandler(
    IMapper mapper,
    ICartItemService answerService) : ICommandHandler<CartItemUpdateCommand, CartItemDto>
{
    public async Task<CartItemDto> Handle(CartItemUpdateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<CartItem>(request.CartItemDto);

        var createdAnswer = await answerService.UpdateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<CartItemDto>(createdAnswer);
    }
}
