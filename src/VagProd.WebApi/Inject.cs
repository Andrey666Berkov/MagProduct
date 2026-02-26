using MagProduct.Application.Interfaces;
using VagProd.WebApi.AutoMapper;
using VagProd.WebApi.Seeding;

namespace VagProd.WebApi;

public static class InjectWebApi
{
    public static IServiceCollection AddWebApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MapProfileApi));
        services.AddTransient<Seed>();
        
        return services;
    }
}