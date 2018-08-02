using System;

namespace CarDealer.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Import Data
            //DataLoader.LoadSuppliers();
            //DataLoader.LoadParts();
            //DataLoader.LoadCars();
            //DataLoader.GeneratePartCars();
            //DataLoader.LoadCustomers();
            //DataLoader.GenerateSales();

            //DataExporter.CarsWithDistanceExport();//Query 1 - Cars with Distance
            //DataExporter.CarsFromFerrari();//Query 2 - Cars from make Ferrari
            //DataExporter.LocalSuppliers();//Query 3 - Local suppliers
            //DataExporter.CarsWithParts();//Query 4 - Cars with parts
            //DataExporter.TotalSalesByCustomer();//Query 5 - Total Sales by Customer
            DataExporter.SalesWithDiscount();//Query 6 - Sales with Applied Discount
        }
    }
}
