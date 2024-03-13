using ShopInventory.API.Models;

namespace ShopInventory.API.Services.Interfaces;

public interface IShopDbRepository
{
    Task<int> GetArtigosCountAsync();
    Task<IEnumerable<Artigo>> GetArtigosAsync(int pageSize, int pageNumber, string? name = null);
}
