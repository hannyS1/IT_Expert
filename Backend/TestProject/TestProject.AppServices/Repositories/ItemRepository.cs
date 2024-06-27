using System.Text;
using Dapper;
using TestProject.Api.Contracts.Web;
using TestProject.Database;
using TestProject.Entities;

namespace TestProject.AppServices.Repositories;

internal class ItemRepository : IItemRepository
{
    private readonly IConnectionProvider _connectionProvider;
    
    public ItemRepository(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider ?? throw new ArgumentNullException(nameof(connectionProvider));
    }
    
    public async Task<IEnumerable<Item>> GetByFilterAsync(GetItemsQueryFilter filter)
    {
        using var connection = _connectionProvider.GetConnection();

        var parameters = new DynamicParameters();
        var queryBuilder = new StringBuilder("select * from items where 1=1");

        if (filter.Code.HasValue)
        {
            queryBuilder.Append(" and code=@code");
            parameters.Add("@code", filter.Code);
        }

        if (!string.IsNullOrWhiteSpace(filter.Value))
        {
            queryBuilder.Append(" and value=@value");
            parameters.Add("@value", filter.Value);
        }
        
        return await connection.QueryAsync<Item>(queryBuilder.ToString(), parameters);
    }

    public async Task OverwriteData(IEnumerable<Item> items)
    {
        using var connection = _connectionProvider.GetConnection();

        const string clearTableQuery = "delete from items where 1=1; alter sequence items_id_seq restart with 1";
        await connection.ExecuteAsync(clearTableQuery);
        
        const string insertQuery = "insert into items (code, value) VALUES (@code, @value)";
        await connection.ExecuteAsync(insertQuery, items);
    }
}