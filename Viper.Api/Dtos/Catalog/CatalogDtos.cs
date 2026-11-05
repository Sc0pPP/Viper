using System;
using System.Collections.Generic;
namespace Viper.Api.Dtos.Catalog;

/// <summary>Параметры поиска и фильтрации каталога (GET /api/products?...).</summary>
public record ProductQuery
{
    public string? Search { get; init; }
    public int? CategoryId { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;
}

/// <summary>Товар в списке каталога.</summary>
/// <param name="Rating">Средняя оценка по отзывам; null, если отзывов нет.</param>
/// <param name="CanBuy">IsActive и Stock &gt; 0 — считает сервер.</param>
public record ProductListItemDto(
    int Id,
    string Name,
    decimal Price,
    string? ImageUrl,
    int CategoryId,
    string CategoryName,
    double? Rating,
    int ReviewsCount,
    int Stock,
    bool CanBuy);

/// <summary>Карточка товара.</summary>
public record ProductDetailsDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string? ImageUrl,
    int CategoryId,
    string CategoryName,
    double? Rating,
    int ReviewsCount,
    int Stock,
    int? UnitsPerPack,
    bool IsActive,
    bool CanBuy);

public record CategoryDto(int Id, string Name);

public record PickupPointDto(int Id, string Name, string Address);
