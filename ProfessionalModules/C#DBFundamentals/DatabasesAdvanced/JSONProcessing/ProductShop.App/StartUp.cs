using AutoMapper;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace ProductShop.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Import Data
            //DataLoader.ImportUsers();
            //DataLoader.ImportProducts();
            //DataLoader.ImportCategories();
            //DataLoader.GenerateCategoryProducts();

            //Export Data
            //DataExporter.ProductsInRange(); //Query 1 - Products in range
            //DataExporter.SuccessfullySoldProducts(); //Query 2 - Successfully Sold Products
            //DataExporter.CategoriesByProductsCount(); //Query 3 - Categories By Products Count
            //DataExporter.UsersAndProducts(); //Query 4 - Users and Products
        }

    }
}
