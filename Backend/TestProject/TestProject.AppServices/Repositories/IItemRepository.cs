using TestProject.Api.Contracts.Web;
using TestProject.Entities;

namespace TestProject.AppServices.Repositories;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetByFilterAsync(GetItemsQueryFilter filter);

    Task FetchData(IEnumerable<Item> items);
}