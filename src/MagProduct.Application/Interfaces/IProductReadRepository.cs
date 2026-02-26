using MagProduct.Core;

namespace MagProduct.Application.Interfaces;

public interface IProductReadRepository
{
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task<Product?> GetProductById(Guid id);
    public Task<Product?> GetProductTittle(string title);
}