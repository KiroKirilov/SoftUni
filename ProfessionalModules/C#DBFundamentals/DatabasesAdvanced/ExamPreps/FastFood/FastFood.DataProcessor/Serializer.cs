using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using Newtonsoft.Json;
using Json=Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var employees = context.Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new
                {
                    Name = e.Name,
                    Orders = e.Orders.Where(o => o.Type.ToString() == orderType)
                        .Select(o => new
                        {
                            Customer = o.Customer,
                            Items = o.OrderItems.Select(oi => new
                            {
                                Name = oi.Item.Name,
                                Price = oi.Item.Price,
                                Quantity = oi.Quantity
                            })
                            .ToArray(),
                            TotalPrice = o.OrderItems.Sum(oi => oi.Quantity * oi.Item.Price)
                        })
                        .OrderByDescending(o=>o.TotalPrice)
                        .ThenByDescending(o=>o.Items.Length),
                    TotalMade = context.Orders.Where(o => o.Employee.Name == employeeName && o.Type.ToString() == orderType)
                        .Sum(o=>o.OrderItems.Sum(oi=>oi.Quantity*oi.Item.Price))
                })
                .First();

            return JsonConvert.SerializeObject(employees,Json.Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoriesToExport = categoriesString.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var categories = context.Categories
                .Where(c => categoriesToExport.Any(x => x == c.Name))
                .Select(c => new CategoryDto()
                {
                    Name = c.Name,
                    MostPopularItem = c.Items.OrderByDescending(i => i.Price * i.OrderItems.Sum(oi => oi.Quantity))
                        .Select(i => new ItemDto()
                        {
                            Name = i.Name,
                            TotalMade = Math.Round(i.Price * i.OrderItems.Sum(oi => oi.Quantity), 2),
                            TimesSold = i.OrderItems.Sum(oi=>oi.Quantity)
                        }).First()
                })
                .OrderByDescending(i => i.MostPopularItem.TotalMade)
                .ThenByDescending(i => i.MostPopularItem.TimesSold)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            return sb.ToString();
        }
    }
}