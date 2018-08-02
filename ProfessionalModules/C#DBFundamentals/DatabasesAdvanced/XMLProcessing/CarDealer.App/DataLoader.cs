using AutoMapper;
using CarDealer.App.Dtos.ImportDtos;
using CarDealer.Data;
using CarDealer.Models;
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
        public static void LoadSuppliers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            var xmlString = File.ReadAllText(@"XmlInput/suppliers.xml");

            var serializer = new XmlSerializer(typeof(SupplierImportDto[]),new XmlRootAttribute("suppliers"));

            var deserializedData = (SupplierImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in deserializedData)
            {
                if (!IsValid(supplierDto))
                {
                    continue;
                }

                var supplier = mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            var context = new CarDealerContext();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        public static void LoadParts()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            var xmlString = File.ReadAllText(@"XmlInput/parts.xml");

            var serializer = new XmlSerializer(typeof(PartsImportDto[]), new XmlRootAttribute("parts"));

            var deserializedData = (PartsImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var parts = new List<Part>();

            foreach (var partDto in deserializedData)
            {
                if (!IsValid(partDto))
                {
                    continue;
                }

                var part = mapper.Map<Part>(partDto);
                var supplierId = new Random().Next(1, 32);
                part.SupplierId = supplierId;
                parts.Add(part);
            }

            var context = new CarDealerContext();
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        public static void LoadCars()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            var xmlString = File.ReadAllText(@"XmlInput/cars.xml");

            var serializer = new XmlSerializer(typeof(CarImportDto[]), new XmlRootAttribute("cars"));

            var deserializedData = (CarImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var cars = new List<Car>();

            foreach (var carDto in deserializedData)
            {
                if (!IsValid(carDto))
                {
                    continue;
                }

                var car = mapper.Map<Car>(carDto);
                
                cars.Add(car);
            }

            var context = new CarDealerContext();
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        public static void LoadCustomers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            var xmlString = File.ReadAllText(@"XmlInput/customers.xml");

            var serializer = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("customers"));

            var deserializedData = (CustomerImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();

            foreach (var customerDto in deserializedData)
            {
                if (!IsValid(customerDto))
                {
                    continue;
                }

                var customer = mapper.Map<Customer>(customerDto);
                customers.Add(customer);
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
