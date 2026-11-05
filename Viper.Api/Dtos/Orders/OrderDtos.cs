using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Viper.Api.Dtos.Catalog;
using Viper.Api.Dtos.Common;

namespace Viper.Api.Dtos.Orders;

/// <summary>
/// Способ получения. Для Delivery нужен Address, для Pickup — PickupPointId.
/// Правило «меньше 600 ₽ — только ПВЗ» проверяет сервер.
/// </summary>
public record DeliveryRequest(
    DeliveryType Type,
    [StringLength(300)] string? Address,
    int? PickupPointId);

public record BuyNowRequest(
    [Range(1, int.MaxValue)] int ProductId,
    [Range(1, 1000)] int Quantity,
    [Required] DeliveryRequest Delivery);

public record CheckoutRequest(
    [Required] DeliveryRequest Delivery);

public record OrderListItemDto(
    int Id,
    DateTime CreatedAtUtc,
    decimal Total,
    int ItemsCount,
    OrderStatus Status,
    DeliveryType DeliveryType);

/// <param name="UnitPrice">Цена на момент покупки, а не текущая цена товара.</param>
public record OrderItemDto(
    int ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal LineTotal);

public record OrderDetailsDto(
    int Id,
    int UserId,
    string UserLogin,
    DateTime CreatedAtUtc,
    OrderStatus Status,
    DeliveryType DeliveryType,
    string? Address,
    PickupPointDto? PickupPoint,
    IReadOnlyList<OrderItemDto> Items,
    decimal Total);

