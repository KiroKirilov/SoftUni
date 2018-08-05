using CarDealer.Data;
using Newtonsoft.Json;
using Json=Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer.App
{
    public static class DataExporter
    {
        public static void SalesWithAppliedDiscount()
        {
            var context = new CarDealerContext();

            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount,
                    price = s.Car.PartsCars.Sum(cp => cp.Part.Price),
                    priceWithDiscount = s.Car.PartsCars.Sum(cp => cp.Part.Price) * ((100 - s.Discount) / 100)
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(sales, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/6-sales-with-applied-discount.json", output);
        }

        public static void TotalSalesByCustomer()
        {
            var context = new CarDealerContext();

            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var output = JsonConvert.SerializeObject(customers, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/5-total-sales-by-customer.json", output);
        }

        public static void CarsWithParts()
        {
            var context = new CarDealerContext();

            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartsCars.Select(cp => new
                    {
                        Name = cp.Part.Name,
                        Price = cp.Part.Price
                    })
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(cars, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/4-cars-with-their-parts.json", output);
        }

        public static void LocalSuppliers()
        {
            var context = new CarDealerContext();

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(suppliers, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/3-local-suppliers.json", output);
        }

        public static void CarsFromMakeToyota()
        {
            var context = new CarDealerContext();

            var cars = context.Cars
                .Where(c => c.Make.ToLower() == "toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c=>new
                {
                    Id=c.Id,
                    Make=c.Make,
                    Model=c.Model,
                    TravelledDistance=c.TravelledDistance
                })
                .ToArray();

            var output = JsonConvert.SerializeObject(cars, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/2-cars-from-make-toyota.json", output);
        }

        public static void OrderedCustomers()
        {
            var context = new CarDealerContext();
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToArray();
                

            var output = JsonConvert.SerializeObject(customers, Json.Formatting.Indented);

            File.WriteAllText(@"JsonOutput/1-ordered-customers.json", output);
        }
    }
}
