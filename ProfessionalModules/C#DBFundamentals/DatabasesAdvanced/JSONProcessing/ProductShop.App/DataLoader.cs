using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.App
{
    public static class DataLoader
    {
        public static void ImportUsers()
        {
            var jsonString = File.ReadAllText("JsonInput/users.json");

            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

            var users = new List<User>();

            foreach (var user in deserializedUsers)
            {
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            var context = new ProductShopContext();
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static void ImportCategories()
        {
            var jsonString = File.ReadAllText("JsonInput/categories.json");

            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

            var categories = new List<Category>();

            foreach (var category in deserializedCategories)
            {
                if (IsValid(category))
                {
                    categories.Add(category);
                }
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        public static void ImportProducts()
        {
            var jsonString = File.ReadAllText("JsonInput/products.json");

            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            var products = new List<Product>();

            var counter = 0;

            foreach (var product in deserializedProducts)
            {
                if (IsValid(product))
                {
                    if (counter % 7 != 0)
                    {
                        product.BuyerId = new Random().Next(1, 57);
                    }
                    else
                    {
                        product.BuyerId = null;
                    }

                    product.SellerId = new Random().Next(1, 57);

                    products.Add(product);
                    counter++;
                }
            }

            var context = new ProductShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void GenerateCategoryProducts()
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
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

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
