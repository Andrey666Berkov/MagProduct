using CSharpFunctionalExtensions;
using MagProd.Infrastructure;
using MagProduct.Application.Dto;
using MagProduct.Application.Interfaces;
using MagProduct.Core;
using MagShared;
using Result = CSharpFunctionalExtensions.Result;

namespace MagProduct.Application.UseCase;

public class GetProductsUseCase(
    IProductWriteRepository writeRepository,
    IProductReadRepository readRepository)
{
    public async Task<Result<List<Product>, ErrorMy>> UseCase()
    {
        var products = await readRepository.GetAllProducts();

        return products.ToList();
    }  
}



