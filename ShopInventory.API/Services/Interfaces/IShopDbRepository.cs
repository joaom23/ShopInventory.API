using ShopInventory.API.Shared;

namespace ShopInventory.API.Services.Interfaces;

public interface IShopDbRepository
{
    Task<int> GetArtigosCountAsync();
    Task<ArtigosResponse> GetArtigosAsync(int pageSize, int pageNumber, string? name = null);
}
