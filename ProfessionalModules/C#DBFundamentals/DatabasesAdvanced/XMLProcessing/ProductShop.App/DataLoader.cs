using AutoMapper;
using ProductShop.App.Dtos;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace ProductShop.App
{
    public static class DataLoader
    {
        public static void GenerateCategoryProducts()
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 201; productId <= 400; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };
                categoryProducts.Add(categoryProduct);
            }

            var context = new ProductShopContext();
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        public static void ReadCategories()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = config.CreateMapper();

            var categoriesXml = File.ReadAllText(@"XmlInput/categories.xml");

            var serializer = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("categories"));

            var deserializedCategories = (CategoryImportDto[])serializer.Deserialize(new StringReader(categoriesXml));

            var categories = new List<Category>();

            foreach (var categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }

                var category = mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public static void ReadProducts()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = config.CreateMapper();

            var productsXml = File.ReadAllText(@"XmlInput/products.xml");

            var serializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("products"));

            var deserializedProducts = (ProductImportDto[])serializer.Deserialize(new StringReader(productsXml));

            var products = new List<Product>();

            var counter = 0;

            foreach (var productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 56);
                var sellerId = new Random().Next(57, 112);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if (counter == 5)
                {
                    product.BuyerId = null;
                    counter = -1;
                }

                counter++;

                products.Add(product);
            }

            var context = new ProductShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void ReadUsers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = config.CreateMapper();

            var userXml = File.ReadAllText(@"XmlInput/users.xml");

            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("users"));

            var deserializedUsers = (UserImportDto[])serializer.Deserialize(new StringReader(userXml));

            var users = new List<User>();
            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            var context = new ProductShopContext();

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResult = new List<DataAnnotations.ValidationResult>();

            return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}
