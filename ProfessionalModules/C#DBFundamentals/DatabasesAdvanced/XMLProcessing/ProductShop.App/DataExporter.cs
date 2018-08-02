using ProductShop.App.Dtos.ExportDtos;
using ProductShop.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop.App
{
    public static class DataExporter
    {
        public static void ExportUsersAndProducts()
        {
            var context = new ProductShopContext();

            var users = new UsersRootExportDto()
            {
                Count = context.Users.Count(),
                Users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UserWithProductsExportDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age.ToString(),
                    SoldProducts = new UserSoldProductsDto()
                    {
                        Count = x.ProductsSold.Count(),
                        SoldProducts = x.ProductsSold.Select(k => new SoldProductWithAttributesDto()
                        {
                            Name = k.Name,
                            Price = k.Price
                        }).ToArray()
                    }
                }).ToArray()
            };

            var serializer = new XmlSerializer(typeof(UsersRootExportDto), new XmlRootAttribute("users"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/user-and-products.xml", sb.ToString());
        }

        public static void ExportCategoriesByProductCount()
        {
            var context = new ProductShopContext();
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new CategoryExportDto()
                {
                    Name = x.Name,
                    ProductCount = x.CategoryProducts.Count,
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price),
                    AveragePrice = x.CategoryProducts.Select(p => p.Product.Price)
                    .DefaultIfEmpty(0)
                    .Average()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryExportDto[]), new XmlRootAttribute("categories"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/categories-by-products-count.xml", sb.ToString());
        }

        public static void ExportSoldProducts()
        {
            var context = new ProductShopContext();
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UserExportDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(s => new SoldProductDto()
                        {
                            Name = s.Name,
                            Price = s.Price
                        })
                            .ToArray()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("users"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/sold-products.xml", sb.ToString());
        }

        public static void ExportProductsInRange()
        {
            var context = new ProductShopContext();
            var products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderByDescending(p => p.Price)
                .Select(x => new ProductExportDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProductExportDto[]), new XmlRootAttribute("products"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/products-in-range.xml", sb.ToString());
        }
    }
}
