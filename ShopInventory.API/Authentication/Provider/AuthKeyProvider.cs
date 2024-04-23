using ShopInventory.API.Authentication.Provider.Interfaces;

namespace ShopInventory.API.Authentication.Provider;

public class ApiKeyProvider : IApiKeyProvider
{
    private readonly IConfiguration _configuration;
    public ApiKeyProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetApiKey()
    {
        return _configuration.GetValue<string>(AuthConstants.ApiKeyName)!;
    }
}
