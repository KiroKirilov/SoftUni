using CarDealer.App.Dtos.ExportDtos.Query1;
using CarDealer.App.Dtos.ExportDtos.Query2;
using CarDealer.App.Dtos.ExportDtos.Query3;
using CarDealer.App.Dtos.ExportDtos.Query4;
using CarDealer.App.Dtos.ExportDtos.Query5;
using CarDealer.App.Dtos.ExportDtos.Query6;
using CarDealer.App.Dtos.ImportDtos;
using CarDealer.Data;
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
        public static void CarsWithDistanceExport()
        {
            var context = new CarDealerContext();
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .Select(x => new CarExportDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarExportDto[]), new XmlRootAttribute("cars"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/1-cars-with-distance.xml", sb.ToString());
        }

        public static void CarsFromFerrari()
        {
            var context = new CarDealerContext();
            var cars = context.Cars
                .Where(x => x.Make.ToLower() == "ferrari")
                .Select(x => new FerrariDto()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var serializer = new XmlSerializer(typeof(FerrariDto[]), new XmlRootAttribute("cars"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/2-cars-from-ferrari.xml", sb.ToString());
        }

        public static void LocalSuppliers()
        {
            var context = new CarDealerContext();
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSupplierDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(LocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), suppliers, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/3-local-suppliers.xml", sb.ToString());
        }

        public static void CarsWithParts()
        {
            var context = new CarDealerContext();
            var cars = context.Cars
                .Select(x => new CarWithPartsDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartsCars.Select(p => new PartDto()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    }).ToArray()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithPartsDto[]), new XmlRootAttribute("cars"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), cars, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/4-cars-with-parts.xml", sb.ToString());
        }

        public static void TotalSalesByCustomer()
        {
            var context = new CarDealerContext();
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new CustomerDto()
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price * p.Part.Quantity))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("customers"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), customers, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/5-total-sales-by-customer.xml", sb.ToString());
        }

        public static void SalesWithDiscount()
        {
            var context = new CarDealerContext();
            var sales = context.Sales
                .Select(x => new SaleDto()
                {
                    CustomerName = x.Customer.Name,
                    Discount = x.Discount / 100,
                    Price = x.Car.PartsCars.Sum(p => p.Part.Price * p.Part.Quantity),
                    PriceWithDiscount = x.Car.PartsCars.Sum(p => p.Part.Price * p.Part.Quantity)*((100m-x.Discount)/100)
                }).ToArray();

            var serializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("sales"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), sales, xmlNamespaces);

            File.WriteAllText(@"XmlOutput/6-sales-with-discount.xml", sb.ToString());
        }
    }
}
