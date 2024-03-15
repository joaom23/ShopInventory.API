using Microsoft.EntityFrameworkCore;
using ShopInventory.API.Databases;
using ShopInventory.API.Services;
using ShopInventory.API.Services.Interfaces;
using EntityFrameworkCore.UseRowNumberForPaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopInventoryContext"), builder => builder.UseRowNumberForPaging());
});

builder.Services.AddScoped<IShopDbRepository, ShopDbRepository>();
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
