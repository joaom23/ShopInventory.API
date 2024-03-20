using ShopInventory.API.Dtos;

namespace ShopInventory.API.Services.Interfaces;

public interface IShopDbRepository
{
    Task<int> GetArtigosCountAsync();
    Task<IEnumerable<ArtigoDto>> GetArtigosAsync(int pageSize, int pageNumber, string? name = null);
}
