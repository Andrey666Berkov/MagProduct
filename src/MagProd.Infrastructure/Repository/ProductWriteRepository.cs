using MagProd.Infrastructure.Context;
using MagProduct.Application.Interfaces;
using MagProduct.Core;
using Microsoft.EntityFrameworkCore;

namespace MagProd.Infrastructure.Repository;

public class ProductWriteRepository : IProductWriteRepository
{
    public AppDbContext db { get; }

    public ProductWriteRepository(AppDbContext dbContext)
    {
        db = dbContext;
    }
    
    
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var products = await db.Products.AsNoTracking().ToListAsync();
        return products;
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await db.Products.FirstOrDefaultAsync(c=>c.Id==id);
        
    }
    
    public async Task<Product?> GetProductTittle(string  tittle)
    {
        return await db.Products.FirstOrDefaultAsync(c=>c.Title==tittle);
        
    }

    public async Task AddProduct(Product product)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();
    }
    
    public async Task DeleteProduct(Product product)
    {
        db.Products.Remove(product);
        await db.SaveChangesAsync();
    }
}