using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopInventory.API.Databases;
using ShopInventory.API.Dtos;
using ShopInventory.API.ExtentionMethods;
using ShopInventory.API.Services.Interfaces;

namespace ShopInventory.API.Services;

public class ShopDbRepository : IShopDbRepository
{
    private readonly AppDbContext _dbContext;

    public ShopDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ArtigoDto>> GetArtigosAsync(int pageSize, int pageNumber, string? name)
    {
        var pagesToSkip = (pageNumber - 1) * pageSize;

        var query = _dbContext.Artigos
            .Include(x => x.ArtigoMoeda)
            .Select(x => new
            {
                x.Descricao,
                x.Stkactual,
                ArtigoMoedaPrice = x.ArtigoMoeda.Select(am => am.Pvp1).FirstOrDefault()
            });

        if (!string.IsNullOrEmpty(name))
        {
            name = name.RemoveDiacritics();
            query = query.Where(x => x.Descricao!.Contains(name));
        }

        var artigosFromDb = await query
            .Skip(pagesToSkip)
            .Take(pageSize)
            .ToListAsync();

        var artigos = artigosFromDb.Select(artigo =>
        {
            double stock = artigo.Stkactual ?? 0;
            double price = artigo.ArtigoMoedaPrice ?? 0;

            return new ArtigoDto
            {
                Name = artigo.Descricao ?? string.Empty,
                Quantity = Math.Max(stock, 0),
                Price = price
            };
        });

        return artigos;
    }

    public async Task<int> GetArtigosCountAsync()
    {
        return await _dbContext.Artigos.CountAsync();
    }
}
