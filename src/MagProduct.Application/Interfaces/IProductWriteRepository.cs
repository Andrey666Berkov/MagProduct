using MagProduct.Core;

namespace MagProduct.Application.Interfaces;

public interface IProductWriteRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(int id);
    Task AddProduct(Product product);
    Task DeleteProduct(Product product);
    public Task<Product?> GetProductTittle(string tittle);
}