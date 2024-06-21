using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        // serviceCollection.AddDbContext<ApplicationDbContext>(builder => builder.UseInMemoryDatabase("database"));
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("MedicalLabApi")));
    }
}