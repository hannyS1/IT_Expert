using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace TestProject.Database;

public static class Migrator
{
    private static void Migrate(IDbConnection connection)
    {
        connection.Execute(@"create table if not exists items(
            id int primary key generated always as identity,
            code int not null,
            value varchar(255) not null
        );");
    }
    
    public static void MigratePostgres(IConfiguration configuration)
    {
        var connection = new PostgresConnectionProvider(configuration).GetConnection();
        Migrate(connection);
    }
}