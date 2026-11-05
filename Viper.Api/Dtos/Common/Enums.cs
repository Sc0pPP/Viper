using System;
using System.Collections.Generic;
namespace Viper.Api.Dtos.Common;

/// <summary>
/// Статус заказа. Числа совпадают с Id в таблице-справочнике OrderStatuses (её заполняет сид).
/// </summary>
public enum OrderStatus
{
    Placed = 1,          // Оформлен
    Processing = 2,      // В обработке
    InDelivery = 3,      // Передан в доставку
    ReadyForPickup = 4,  // Готов к выдаче
    Received = 5,        // Получен
    Cancelled = 6        // Отменён
}

/// <summary>Способ получения заказа.</summary>
public enum DeliveryType
{
    Pickup = 1,    // Самовывоз из ПВЗ
    Delivery = 2   // Доставка по адресу
}

/// <summary>Сортировка истории заказов по дате.</summary>
public enum SortDirection
{
    Desc = 0,  // сначала новые
    Asc = 1    // сначала старые
}
