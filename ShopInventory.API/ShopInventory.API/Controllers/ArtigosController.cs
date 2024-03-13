using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ShopInventory.API.Models;
using ShopInventory.API.Services.Interfaces;

namespace ShopInventory.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtigosController : ControllerBase
{
    private readonly ILogger<ArtigosController> _logger;
    private readonly IShopDbRepository _shopDbService;

    public ArtigosController(ILogger<ArtigosController> logger, IShopDbRepository shopDbService)
    {
        _logger = logger;
        _shopDbService = shopDbService;
    }

    [HttpGet]
    public async Task<IEnumerable<Artigo>> GetArtigosAsync(int pageSize = 2, int pageNumber = 1, string? name = null)
    {
        return await _shopDbService.GetArtigosAsync(pageSize, pageNumber, name);
    }

    [HttpGet("Count")]
    public async Task<int> GetArtigosCountAsync()
    {
        return await _shopDbService.GetArtigosCountAsync();
    }
}
