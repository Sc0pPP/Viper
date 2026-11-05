using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Viper.Api.Dtos.Common;

namespace Viper.Api.Dtos.Admin;

/// <summary>Создание и редактирование товара админом.</summary>
public record ProductUpsertRequest(
    [Required, StringLength(200)] string Name,
    [Required, StringLength(4000)] string Description,
    [Range(typeof(decimal), "0.01", "10000000")] decimal Price,
    [Range(1, int.MaxValue)] int CategoryId,
    [StringLength(260)] string? ImageFileName,
    [Range(0, int.MaxValue)] int Stock,
    [Range(1, 10000)] int? UnitsPerPack,
    bool IsActive = true);

public record SetProductActiveRequest(bool IsActive);

public record SetStockRequest([Range(0, int.MaxValue)] int Stock);

public record CategoryUpsertRequest(
    [Required, StringLength(100)] string Name);

public record PickupPointUpsertRequest(
    [Required, StringLength(100)] string Name,
    [Required, StringLength(300)] string Address);

public record ChangeOrderStatusRequest(OrderStatus Status);
