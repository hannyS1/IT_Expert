using System.Data;

namespace TestProject.Database;

public interface IConnectionProvider
{
    IDbConnection GetConnection();
}