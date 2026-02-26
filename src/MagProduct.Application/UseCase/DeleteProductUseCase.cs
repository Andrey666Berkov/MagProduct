using CSharpFunctionalExtensions;
using MagProduct.Application.Interfaces;
using MagProduct.Core;
using MagShared;

namespace MagProduct.Application.UseCase;

public class DeleteProductUseCase(IProductWriteRepository repository)
{
    public async Task<Result<Product, ErrorMy>> UseCase(int  id)
    {
        var productResult = await repository.GetProductById(id);
        if(productResult == null)
            return ErrorsMy.General.NotFound();
        
        await repository.DeleteProduct(productResult);
        
       
        return productResult;
    }  
}