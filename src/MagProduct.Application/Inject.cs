using MagProduct.Application.UseCase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagProduct.Application;

public static class InjectApplications
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AddProductUseCase>();
        services.AddScoped<DeleteProductUseCase>();
        services.AddScoped<GetProductsUseCase>();
        
        
        return services;
    }
}