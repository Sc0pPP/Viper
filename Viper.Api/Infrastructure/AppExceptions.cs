namespace Viper.Api.Infrastructure;

/// <summary>
/// Базовое исключение бизнес-логики. Сервисы бросают его наследников,
/// а <see cref="AppExceptionHandler"/> превращает их в ProblemDetails с нужным HTTP-кодом.
/// </summary>
public abstract class AppException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}

/// <summary>404 — сущность не найдена (или чужая, и мы не палим, что она существует).</summary>
public sealed class NotFoundException(string message) : AppException(message, StatusCodes.Status404NotFound);

/// <summary>400 — нарушено бизнес-правило: мало на складе, доставка дешевле 600 ₽ и т.п.</summary>
public sealed class BusinessRuleException(string message) : AppException(message, StatusCodes.Status400BadRequest);

/// <summary>409 — конфликт: логин уже занят, дубликат и т.п.</summary>
public sealed class ConflictException(string message) : AppException(message, StatusCodes.Status409Conflict);

/// <summary>403 — пользователь вошёл, но прав не хватает.</summary>
public sealed class ForbiddenException(string message) : AppException(message, StatusCodes.Status403Forbidden);
