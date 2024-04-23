using ShopInventory.API.Authentication;
using System.Threading.RateLimiting;

namespace ShopInventory.API.RateLimit;

public static class RateLimit
{
    public static IServiceCollection AddCustomRateLimit(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddPolicy("IpPolicy", context =>
            {
                var apiKey = context.GetApiKeyFromHeader();

                return RateLimitPartition.GetFixedWindowLimiter(
                //partitionKey: context.Connection.RemoteIpAddress,
                partitionKey: apiKey,
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 3,
                    QueueLimit = 0,
                    Window = TimeSpan.FromMinutes(1)
                });
            });

            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;
                await context.HttpContext.Response.WriteAsJsonAsync($"Too many requests for API key {context.HttpContext.GetApiKeyFromHeader()}. Please try later again...", token);
            };
        });

        return services;
    }
}
