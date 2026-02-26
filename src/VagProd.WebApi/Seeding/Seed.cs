using System.Text.Json;
using MagProd.Infrastructure;
using MagProd.Infrastructure.Context;
using MagProduct.Application.Interfaces;
using MagProduct.Core;


namespace VagProd.WebApi.Seeding;

public class Seed(IProductWriteRepository repository, AppDbContext dbContext)
{
    public async Task Seeding()
    {
        var exists = dbContext.Products.Any();
        if (!exists)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://fakestoreapi.com");
            var result=await client.GetStringAsync("/products");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Если у вас разные стили написания
                //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Игнорировать null значения
                // AllowTrailingCommas = true, // Разрешить незначительные запятые в JSON
                // Converters = { new JsonStringEnumConverter() }  // Если у вас есть перечисления
            };
            var products = JsonSerializer.Deserialize<List<Product>>(result,options); 
            
            foreach (var product in products)
            {
                await repository.AddProduct(product);
            }
        }
        
    }  
}