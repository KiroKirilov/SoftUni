using AutoMapper;
using Company.App.Core.DTOs;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeFullInfoDTO>().ReverseMap();
            CreateMap<Employee, ManagerDTO>()
                .ForMember(destinationMember => destinationMember.Employees,
                            from=>from.MapFrom(x=>x.ManagerEmployees))
                .ReverseMap();
            CreateMap<Employee, EmployeeProjectionDTO>().ReverseMap();
        }
    }
}
