using AutoMapper;
using ProductShop.App.Dtos;
using ProductShop.App.Dtos.ExportDtos;
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
            //DataLoader.ReadUsers();
            //DataLoader.ReadProducts();
            //DataLoader.ReadCategories();
            //DataLoader.GenerateCategoryProducts();

            //Export Data
            //ExportProductsInRange(); //Query 1 - Products in range
            //ExportSoldProducts(); //Query 2 - Sold Products
            //ExportCategoriesByProductCount(); //Query 3 - Categories By Products Count
            //ExportUsersAndProducts(); //Query 4 - Users and Products
        }

    }
}
