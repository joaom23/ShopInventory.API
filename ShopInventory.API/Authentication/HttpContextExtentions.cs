namespace ShopInventory.API.Authentication;

public static class HttpContextExtentions
{
    public static string? GetApiKeyFromHeader(this HttpContext context)
    {
        context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedKey);
        return extractedKey;
    }
}
