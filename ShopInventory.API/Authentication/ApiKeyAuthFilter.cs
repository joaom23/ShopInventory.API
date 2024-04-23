using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopInventory.API.Authentication.Provider.Interfaces;

namespace ShopInventory.API.Authentication;

public class ApiKeyAuthFilter : IAuthorizationFilter
{
    private readonly IApiKeyProvider _apiKeyProvider;

    public ApiKeyAuthFilter(IApiKeyProvider apiKeyProvider)
    {
        _apiKeyProvider = apiKeyProvider;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var extractedApiKey = context.HttpContext.GetApiKeyFromHeader();

        if (string.IsNullOrEmpty(extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("API Key missing");
            return;
        }

        var apiKey = _apiKeyProvider.GetApiKey();

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
        }
    }
}
