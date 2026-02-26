using Dapper;
using MagProd.Infrastructure.Context;
using MagProduct.Application.Interfaces;
using MagProduct.Core;

namespace MagProd.Infrastructure.Repository;

public class ProductReadRepository : IProductReadRepository
{
    private readonly DapperDbContext db;

    public ProductReadRepository(DapperDbContext dbdapper)
    {
        db = dbdapper;
    }
    
    public async Task<IEnumerable<Product>?> GetAllProducts()
    {
        using var connection = db.GetConnection();
        string query=@"SELECT * FROM Products";
        var products = await connection.QueryAsync<Product, RatingMap, Product>(query,
            (product, ratingMap) => {
                var rating = new Rating(ratingMap.Rating_Rate, ratingMap.Rating_Count);
                product.CreateRating(rating);
                return product;
            },
            splitOn: "Rating_Rate");
        return products;
    }

    public record RatingMap(double Rating_Rate, int Rating_Count);
    

    public async Task<Product?> GetProductById(Guid id)
    {
        using var connection = db.GetConnection();
        string query=@"SELECT * FROM Products WHERE Id=@Id";
        var products = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        return products;
    }
    
    public async Task<Product?> GetProductTittle(string  title)
    {
        using var connection = db.GetConnection();
        string query=@"SELECT * FROM Products WHERE Id=@Id";
        var products = await connection.QueryFirstOrDefaultAsync<Product>(query, new { Tittle = title });
        return products;
    }
}