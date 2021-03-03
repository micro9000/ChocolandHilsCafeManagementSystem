using AutoMapper;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class EmployeeeSalaryRateProfile : Profile
    {
        public EmployeeeSalaryRateProfile()
        {
            CreateMap<EmployeeSalaryRateModel, EmployeeSalaryRateModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.EmployeeNumber, opt => opt.Ignore());
        }
    }
}
