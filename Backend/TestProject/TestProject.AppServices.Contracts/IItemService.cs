using TestProject.Api.Contracts.Data;
using TestProject.Api.Contracts.Web;

namespace TestProject.AppServices.Contracts;

public interface IItemService
{
    Task<IEnumerable<ItemResponseDto>> GetByFilterAsync(GetItemsQueryFilter filter);

    Task OverwriteData(IEnumerable<Dictionary<int, string>> data);
}