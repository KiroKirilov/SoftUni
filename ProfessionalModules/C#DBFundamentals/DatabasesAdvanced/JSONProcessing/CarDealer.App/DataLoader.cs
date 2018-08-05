using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace CarDealer.App
{
    public static class DataLoader
    {
        public static void ImportSuppliers()
        {
            var jsonString = File.ReadAllText("JsonInput/suppliers.json");

            var deserializedSuppliers = JsonConvert.DeserializeObject<Supplier[]>(jsonString);

            var suppliers = new List<Supplier>();

            foreach (var supplier in deserializedSuppliers)
            {
                if (IsValid(supplier))
                {
                    suppliers.Add(supplier);
                }
            }

            var context = new CarDealerContext();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        public static void ImportParts()
        {
            var jsonString = File.ReadAllText("JsonInput/parts.json");

            var deserializedParts = JsonConvert.DeserializeObject<Part[]>(jsonString);

            var parts = new List<Part>();

            foreach (var part in deserializedParts)
            {
                if (IsValid(part))
                {
                    var supplierId = new Random().Next(1, 32);
                    part.SupplierId = supplierId;
                    parts.Add(part);
                }
            }

            var context = new CarDealerContext();
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        public static void ImportCars()
        {
            var jsonString = File.ReadAllText("JsonInput/cars.json");

            var deserializedCars = JsonConvert.DeserializeObject<Car[]>(jsonString);

            var cars = new List<Car>();

            foreach (var car in deserializedCars)
            {
                if (IsValid(car))
                {
                    cars.Add(car);
                }
            }

            var context = new CarDealerContext();
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        public static void ImportCustomers()
        {
            var jsonString = File.ReadAllText("JsonInput/customers.json");

            var deserializedCustoemrs = JsonConvert.DeserializeObject<Customer[]>(jsonString);

            var customers= new List<Customer>();

            foreach (var customer in deserializedCustoemrs)
            {
                if (IsValid(customer))
                {
                    customers.Add(customer);
                }
            }

            var context = new CarDealerContext();
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        public static void GeneratePartCars()
        {
            var context = new CarDealerContext();
            var partCars = new List<PartCar>();

            foreach (var car in context.Cars)
            {
                var partCar = new PartCar()
                {
                    CarId = car.Id,
                    PartId = new Random().Next(1, 132)
                };

                partCars.Add(partCar);
            }

            context.PartsCars.AddRange(partCars);
            context.SaveChanges();
        }

        public static void GenerateSales()
        {
            var context = new CarDealerContext();
            var discounts = new decimal[] { 0, 5, 10, 15, 20, 30, 40, 50 };
            var sales = new List<Sale>();

            for (int i = 0; i < 150; i++)
            {
                var sale = new Sale()
                {
                    CarId = new Random().Next(1, 359),
                    CustomerId = new Random().Next(1, 31),
                    Discount = discounts[new Random().Next(0, discounts.Length)]
                };
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
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
