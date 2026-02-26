using MagProd.Infrastructure.Repository;
using MagProduct.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagProd.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        // services.AddDbContext<AppDbContext>();
         services.AddDbContext<AppDbContext>
             (op=>op
                 .UseNpgsql("Host=localhost;Port=5435;Database=productdb;Username=postgres;Password=postgres"));

             services.AddScoped<DapperDbContext>();
             services.AddScoped<IProductReadRepository, ProductReadRepository>();
        
        
        return services;
    }
}