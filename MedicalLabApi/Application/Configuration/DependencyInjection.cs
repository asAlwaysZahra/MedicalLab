using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace Application.Configuration;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddInfrastructureServices(configuration);
        serviceCollection.AddAutoMapper(typeof(AutoMapper));
    }
}