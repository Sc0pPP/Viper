using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Viper.Api.Infrastructure;

/// <summary>
/// Глобальный обработчик ошибок: любое исключение превращается в ProblemDetails (RFC 7807).
/// Наши <see cref="AppException"/> отдают свой код и текст, всё остальное — 500 без подробностей.
/// </summary>
public sealed class AppExceptionHandler(
    IProblemDetailsService problemDetails,
    ILogger<AppExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken ct)
    {
        int status;
        string title;

        if (exception is AppException app)
        {
            status = app.StatusCode;
            title = app.Message;
        }
        else
        {
            logger.LogError(exception, "Необработанная ошибка");
            status = StatusCodes.Status500InternalServerError;
            title = "Внутренняя ошибка сервера";
        }

        context.Response.StatusCode = status;
        return await problemDetails.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = context,
            Exception = exception,
            ProblemDetails = new ProblemDetails { Status = status, Title = title }
        });
    }
}
