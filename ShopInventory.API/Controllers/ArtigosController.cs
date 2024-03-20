using Microsoft.AspNetCore.Mvc;
using ShopInventory.API.Databases.Models;
using ShopInventory.API.Dtos;
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
    public async Task<IEnumerable<ArtigoDto>> GetArtigosAsync(int pageSize = 100, int pageNumber = 1, string? name = null)
    {
        return await _shopDbService.GetArtigosAsync(pageSize, pageNumber, name);
    }

    [HttpGet("Count")]
    public async Task<int> GetArtigosCountAsync()
    {
        return await _shopDbService.GetArtigosCountAsync();
    }
}
