using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viper.Api.Dtos.Cart;

public record CartItemDto(
    int ProductId,
    string Name,
    string? ImageUrl,
    decimal UnitPrice,
    int Quantity,
    decimal LineTotal,
    int Stock,
    bool CanBuy);

public record CartDto(IReadOnlyList<CartItemDto> Items, decimal Total);

public record AddCartItemRequest(
    [Range(1, int.MaxValue)] int ProductId,
    [Range(1, 1000)] int Quantity = 1);

public record UpdateCartItemRequest(
    [Range(1, 1000)] int Quantity);

public record FavoriteDto(
    int ProductId,
    string Name,
    decimal Price,
    string? ImageUrl,
    bool CanBuy,
    DateTime AddedAtUtc);
