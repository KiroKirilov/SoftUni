using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var deserializedItems = JsonConvert.DeserializeObject<EmployeeImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var employees = new List<Employee>();

            foreach (var dto in deserializedItems)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var positionId = context.Positions.FirstOrDefault(p => p.Name == dto.Position)?.Id;

                if (positionId == null)
                {
                    var position = new Position()
                    {
                        Name = dto.Position
                    };

                    context.Positions.Add(position);
                    context.SaveChanges();

                    positionId = position.Id;
                }

                var employee = new Employee()
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    PositionId = positionId.Value
                };
                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var deserializedData = JsonConvert.DeserializeObject<ItemImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var items = new List<Item>();

            foreach (var dto in deserializedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var alreadyExists = context.Items.Any(i => i.Name == dto.Name) ||
                    items.Any(i => i.Name == dto.Name);

                if (alreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var categoryId = context.Categories.FirstOrDefault(c => c.Name == dto.Category)?.Id;

                if (categoryId == null)
                {
                    var category = new Category()
                    {
                        Name = dto.Category
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();

                    categoryId = category.Id;
                }

                var item = new Item()
                {
                    CategoryId = categoryId.Value,
                    Name = dto.Name,
                    Price = dto.Price
                };

                items.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OrderImportDto[]), new XmlRootAttribute("Orders"));

            var deserializedData = (OrderImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var orders = new List<Order>();

            foreach (var dto in deserializedData)
            {
                var order = new Order();
                order.Customer = dto.Customer;

                var employeeId = context.Employees.FirstOrDefault(e => e.Name == dto.Employee)?.Id;

                if (employeeId == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                order.DateTime = DateTime.ParseExact(dto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                order.EmployeeId = employeeId.Value;
                order.Type = Enum.Parse<OrderType>(dto.Type);

                var allItemsExist = true;

                var orderItems = new List<OrderItem>();

                foreach (var itemDto in dto.Items)
                {
                    var itemId = context.Items.FirstOrDefault(i=>i.Name==itemDto.Name)?.Id;

                    if (itemId==null)
                    {
                        allItemsExist = false;
                        continue;
                    }

                    var orderItem = new OrderItem()
                    {
                        ItemId = itemId.Value,
                        Quantity = itemDto.Quantity
                    };

                    orderItems.Add(orderItem);

                }

                if (!allItemsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                order.OrderItems = orderItems;

                orders.Add(order);

                sb.AppendLine($"Order for {dto.Customer} on {dto.DateTime} added");

            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}