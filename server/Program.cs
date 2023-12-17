using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
string con = "Server=LAPTOP-NE8A180M\\SQLEXPRESS;Database=zhkh;Trusted_Connection=True;";

// устанавливаем контекст данных
builder.Services.AddDbContext<zhkh>(options => options.UseSqlServer(con));

builder.Services.AddControllers(); // используем контроллеры без представлений

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
