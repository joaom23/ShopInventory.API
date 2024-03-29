using ShopInventory.API.Dtos;

namespace ShopInventory.API.Shared;

public class ArtigosResponse
{
    public List<ArtigoDto> Artigos { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
}
