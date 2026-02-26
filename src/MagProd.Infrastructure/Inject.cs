using MagProd.Infrastructure.Context;
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
                 .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

             services.AddScoped<DapperDbContext>();
             services.AddScoped<IProductReadRepository, ProductReadRepository>();
        
        
        return services;
    }
}