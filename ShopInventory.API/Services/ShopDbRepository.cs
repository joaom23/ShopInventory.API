using Microsoft.EntityFrameworkCore;
using ShopInventory.API.Databases;
using ShopInventory.API.Dtos;
using ShopInventory.API.ExtentionMethods;
using ShopInventory.API.Services.Interfaces;
using ShopInventory.API.Shared;

namespace ShopInventory.API.Services;

public class ShopDbRepository : IShopDbRepository
{
    private readonly AppDbContext _dbContext;

    public ShopDbRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ArtigosResponse> GetArtigosAsync(int pageSize, int pageNumber, string? name)
    {
        var pagesToSkip = (pageNumber - 1) * pageSize;

        //var test = Enumerable.Range(1, 55).Select(i => new ArtigoDto { Name = "test" + i, Quantity = i, Price = i });

        //if (!string.IsNullOrEmpty(name))
        //{
        //    name = name.RemoveDiacritics();
        //    test = test.Where(x => x.Name!.Contains(name));
        //}

        //var artigos = test.Skip(pagesToSkip).Take(pageSize);

        //return new ArtigosResponse()
        //{
        //    Artigos = artigos.ToList(),
        //    CurrentPage = pageNumber,
        //    PageSize = pageSize,
        //    TotalCount = test.Count()
        //};

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

        var totalCount = await query.CountAsync();

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

        return new ArtigosResponse()
        {
            Artigos = artigos.ToList(),
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public async Task<int> GetArtigosCountAsync()
    {
        return await _dbContext.Artigos.CountAsync();
    }
}
