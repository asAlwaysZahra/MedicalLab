using System.ComponentModel.Design;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddInfrastructureServices();
        serviceCollection.AddAutoMapper(typeof(AutoMapper));
    }
}