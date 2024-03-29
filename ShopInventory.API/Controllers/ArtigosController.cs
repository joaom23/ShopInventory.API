using Microsoft.AspNetCore.Mvc;
using ShopInventory.API.Services.Interfaces;
using ShopInventory.API.Shared;

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
    public async Task<ArtigosResponse> GetArtigosAsync(int pageSize = 10, int pageNumber = 1, string? name = null)
    {
        return await _shopDbService.GetArtigosAsync(pageSize, pageNumber, name);
    }

    [HttpGet("Count")]
    public async Task<int> GetArtigosCountAsync()
    {
        return await _shopDbService.GetArtigosCountAsync();
    }
}
