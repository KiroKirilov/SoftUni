using System;

namespace CarDealer.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Import Data
            //DataLoader.ImportSuppliers();
            //DataLoader.ImportParts();
            //DataLoader.ImportCars();
            //DataLoader.GeneratePartCars();
            //DataLoader.ImportCustomers();
            //DataLoader.GenerateSales();

            //Export Data
            //DataExporter.OrderedCustomers(); //Query 1 - Ordered Customers
            //DataExporter.CarsFromMakeToyota(); //Query 2 - Cars from make Toyota
            //DataExporter.LocalSuppliers(); //Query 3 - Local Suppliers
            //DataExporter.CarsWithParts(); //Query 4 - Cars with Their List of Parts
            //DataExporter.TotalSalesByCustomer(); //Query 5 - Total Sales by Customer
            DataExporter.SalesWithAppliedDiscount(); //Query 6 - Sales with Applied Discount
        }
    }
}
