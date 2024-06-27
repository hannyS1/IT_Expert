using Microsoft.AspNetCore.Mvc;
using TestProject.Api.Contracts.Data;
using TestProject.Api.Contracts.Web;
using TestProject.Api.Contracts.WebRoutes;
using TestProject.AppServices.Contracts;

namespace TestProject.Host.Controllers;

[ApiController]
[Route(ItemsWebRoutes.BasePath)]
public class ItemsController
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
    }

    [HttpGet(ItemsWebRoutes.GetByFilter)]
    public Task<IEnumerable<ItemResponseDto>> GetByFilter([FromQuery] GetItemsQueryFilter filter)
    {
        return _itemService.GetByFilterAsync(filter);
    }

    [HttpPost(ItemsWebRoutes.FetchData)]
    public Task FetchData([FromBody] IEnumerable<Dictionary<int, string>> data)
    {
        return _itemService.FetchData(data);
    }
}