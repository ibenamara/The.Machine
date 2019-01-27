using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The.Machine.Entities;
using The.Machine.Models;

namespace The.Machine.Configuration
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<DrinkDTO, Drink>();
            CreateMap<Drink, DrinkDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
