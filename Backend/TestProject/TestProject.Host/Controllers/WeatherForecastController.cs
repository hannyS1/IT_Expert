using Microsoft.AspNetCore.Mvc;
using TestProject.AppServices.Repositories;
using TestProject.Entities;

namespace TestProject.Host.Controllers;

[ApiController]
[Route("test")]
public class WeatherForecastController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    
    public WeatherForecastController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    // [HttpGet("get-all")]
    // public Task<IEnumerable<Item>> GetAllAsync()
    // {
    //     return _itemRepository.GetAllAsync();
    // }
}