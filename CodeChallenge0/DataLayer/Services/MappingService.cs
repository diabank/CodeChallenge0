using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.Models.DbModel;
using CodeChallenge0.Models.ViewModel;

namespace CodeChallenge0.DataLayer.Services
{
    /// <summary>
    /// Mapping Service Domain to View Mode and Vice Versa
    /// </summary>
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<TblEmployee, Employee>()
                 .ForMember(
                    dest => dest.wholeName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

            CreateMap<TblServiceOrder, ServiceOrder>()
                .ForMember(
                    dest => dest.EmployeeName,
                    opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ReverseMap();
        }
    }
}
