using Microsoft.Extensions.DependencyInjection;
using TestProject.AppServices.Contracts;
using TestProject.AppServices.Repositories;

namespace TestProject.AppServices.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddTransient<IItemRepository, ItemRepository>();
        services.AddTransient<IItemService, ItemService>();
        return services;
    }
}