using Scalar.AspNetCore;
using Viper.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- Сервисы ---
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Ошибки: ProblemDetails для всего + наш обработчик бизнес-исключений
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<AppExceptionHandler>();

// TODO (шаг 2): JWT-аутентификация и авторизация по ролям
// TODO (шаг 3+): DbContext из Viper.Data и сервисы (ICatalogService, ICartService, IOrderService, ...)

var app = builder.Build();

// --- Конвейер ---
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                 // /openapi/v1.json
    app.MapScalarApiReference();      // /scalar — UI для ручных запросов
}

app.UseStaticFiles();                 // картинки товаров: /images/<файл>

app.MapControllers();

app.Run();
