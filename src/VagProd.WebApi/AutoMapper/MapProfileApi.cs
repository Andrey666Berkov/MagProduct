using AutoMapper;
using MagProduct.Application.Dto;
using MagProduct.Core;
using VagProd.WebApi.Request;

namespace VagProd.WebApi.AutoMapper;

public class MapProfileApi:Profile
{
    public MapProfileApi()
    {
        CreateMap<ProductAddDto, ProductAddRequest>();
        CreateMap<Product, ProductAddDto>();
    }
}