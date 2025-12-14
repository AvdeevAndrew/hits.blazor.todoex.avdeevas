
using AcademicJournal.Data;
using hits.blazor.todoex.avdeevas.Components; // Попробуйте это, если App лежит в папке Components
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<JournalDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Добавляем сервисы для Razor компонентов и интерактивности
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // !!! ВАЖНО: Включает интерактивность !!!

// 2. Регистрируем наш сервис журнала
builder.Services.AddScoped<JournalService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

// 3. Настраиваем машрутизацию с интерактивным режимом
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // !!! ВАЖНО: Разрешает запуск интерактивности !!!

app.Run();
