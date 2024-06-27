using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Database.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgreSqlConnection(this IServiceCollection services)
    {
        services.AddTransient<IConnectionProvider, PostgresConnectionProvider>();
        return services;
    }
}