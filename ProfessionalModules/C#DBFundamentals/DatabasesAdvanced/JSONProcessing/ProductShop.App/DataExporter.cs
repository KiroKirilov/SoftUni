using Newtonsoft.Json;
using ProductShop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Json = Newtonsoft.Json;

namespace ProductShop.App
{
    public static class DataExporter
    {
        public static void UsersAndProducts()
        {
            var context = new ProductShopContext();

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(x => new
                {
                    usersCount = context.Users.Count(),
                    users = context.Users.Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts=new
                        {
                            count=u.ProductsSold.Count(),
                            products=u.ProductsSold.Select(p=>new
                            {
                                name=p.Name,
                                price=p.Price
                            })
                        }
                    })
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(users, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/4-users-and-products.json", output);
        }

        public static void CategoriesByProductsCount()
        {
            var context = new ProductShopContext();

            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            var output = JsonConvert.SerializeObject(categories, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/3-categories-by-product-count.json", output);
        }

        public static void SuccessfullySoldProducts()
        {
            var context = new ProductShopContext();

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(users, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/2-successfully-sold-products.json", output);
        }

        public static void ProductsInRange()
        {
            var context = new ProductShopContext();
            var products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderByDescending(p => p.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName ?? x.Seller.LastName
                })
                .ToArray();


            var output = JsonConvert.SerializeObject(products, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/1-products-in-range.json", output);
        }
    }
}
