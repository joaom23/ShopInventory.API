using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.EntityFrameworkCore;
using ShopInventory.API.Authentication;
using ShopInventory.API.Authentication.Provider;
using ShopInventory.API.Authentication.Provider.Interfaces;
using ShopInventory.API.Databases;
using ShopInventory.API.RateLimit;
using ShopInventory.API.Services;
using ShopInventory.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopInventoryContext"), builder => builder.UseRowNumberForPaging());
});

services.AddScoped<IApiKeyProvider, ApiKeyProvider>();
services.AddScoped<ApiKeyAuthFilter>();
services.AddScoped<IShopDbRepository, ShopDbRepository>();

services.AddCustomRateLimit();
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

app.Run();
