using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace TestProject.Database;

internal class PostgresConnectionProvider : IConnectionProvider
{
    private readonly string _connectionString;
    
    public PostgresConnectionProvider(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgreSqlConnection");
    }
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}