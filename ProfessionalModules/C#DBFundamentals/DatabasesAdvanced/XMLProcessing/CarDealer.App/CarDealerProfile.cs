using AutoMapper;
using CarDealer.App.Dtos.ImportDtos;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.App
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<CarImportDto, Car>();
            CreateMap<CustomerImportDto, Customer>();
        }
    }
}
