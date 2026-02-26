using CSharpFunctionalExtensions;
using MagProduct.Application.Dto;
using MagProduct.Application.Interfaces;
using MagProduct.Core;
using MagShared;

namespace MagProduct.Application.UseCase;

public class AddProductUseCase(IProductWriteRepository repository)
{
    public async Task<Result<Product, ErrorMy>> UseCase(ProductAddDto productDto)
    {
        var productResult = await repository.GetProductTittle(productDto.Title);
        if(productResult != null)
            return ErrorsMy.General.ValueIsRequired("This is product is required");
        
        var product=Product.Create(
            productDto.Title, 
            productDto.Price, 
            productDto.Description, 
            productDto.Category, 
            productDto.Image,
            productDto.Rating);
        
        await repository.AddProduct(product);
        return product;
    }  
}