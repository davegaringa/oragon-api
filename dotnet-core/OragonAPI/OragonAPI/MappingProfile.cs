using AutoMapper;
using Entities.DataTransferObjects.EmployeeManagement;
using Entities.Models.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OragonAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Employee Management

            CreateMap<Company, CompanyDto>()
                .ForMember(c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<CompanyForUpdateDto, Company>();

            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

            #endregion
        }
    }
}
