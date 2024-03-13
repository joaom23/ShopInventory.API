using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopInventory.API.Databases;
using ShopInventory.API.ExtentionMethods;
using ShopInventory.API.Models;
using ShopInventory.API.Services.Interfaces;
using System.Globalization;
using System.Text;

namespace ShopInventory.API.Services;

public class ShopDbRepository : IShopDbRepository
{
    private readonly AppDbContext _dbContext;

    public ShopDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Artigo>> GetArtigosAsync(int pageSize, int pageNumber, string? name)
    {
        var pagesToSkip = pageNumber - 1;
        
        if (!name.IsNullOrEmpty() && name != null)
        {
            name = name.RemoveDiacritics();
            return await _dbContext.Artigos.Where(x => x.Descricao!.Contains(name)).Skip(pagesToSkip).Take(pageSize).ToListAsync();
        }

        return await _dbContext.Artigos.Skip(pagesToSkip).Take(pageSize).ToListAsync();
    }

    public async Task<int> GetArtigosCountAsync()
    {
        return await _dbContext.Artigos.CountAsync();
    }
}
