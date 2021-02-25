using AutoMapper;
using DataAccess.Entities.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeModel, EmployeeModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.EmployeeNumber, opt => opt.Ignore());
        }
    }
}
