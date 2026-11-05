using System;
using System.Collections.Generic;
namespace Viper.Api.Dtos.Common;

/// <summary>Страница списка: элементы + сколько всего, чтобы UI мог нарисовать пагинацию.</summary>
public record PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize, int TotalCount)
{
    public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
}
