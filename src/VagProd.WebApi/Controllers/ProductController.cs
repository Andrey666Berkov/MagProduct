using AutoMapper;
using MagProduct.Application;
using MagProduct.Application.Dto;
using MagProduct.Application.UseCase;
using MagProduct.Core;
using Microsoft.AspNetCore.Mvc;
using VagProd.WebApi.Request;

namespace VagProd.WebApi.Controllers;

public class ProductController : ApplicationController
{
   [HttpGet("products")]
   public async Task<IActionResult> GetProducts(
      [FromServices] GetProductsUseCase useCase)
   {
      var result = await useCase.UseCase();
    
      return Ok(result.Value);
   }
   
   
   [HttpPost("AddProducts")]
   public async Task<IActionResult> AddProducts(
      [FromServices] IMapper mapper,
      [FromForm] AddProductUseCase addProductUseCase,
      ProductAddRequest product)
   {
      var productAddDto= mapper.Map<ProductAddDto>(product);
      var result=addProductUseCase.UseCase(productAddDto);
      if(result.IsCompleted)
        return Ok(result.Result);
      return BadRequest(result.Result.Error);
   }
   
   [HttpPost("{id:int}/delete")]
   public async Task<IActionResult> AddProducts(
      [FromServices] IMapper mapper,
      [FromForm] DeleteProductUseCase deleteProductUseCase,
      [FromRoute] int id)
   {
      var result=await deleteProductUseCase.UseCase(id);
      if(result.IsSuccess)
         return Ok();
      return BadRequest(result.Error);
   }
   
   [HttpPost("{id:int}/product")]
   public async Task<IActionResult> GetProdictId(Guid id)
   {
    
      return Ok("Registered Successfully");
   }
   
   
}

