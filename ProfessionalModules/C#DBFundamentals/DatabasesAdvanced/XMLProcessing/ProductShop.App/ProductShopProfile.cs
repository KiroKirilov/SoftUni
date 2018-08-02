using AutoMapper;
using ProductShop.App.Dtos;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.App
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserImportDto, User>();
            CreateMap<ProductImportDto, Product>();
            CreateMap<CategoryImportDto, Category>();
        }
    }
}
