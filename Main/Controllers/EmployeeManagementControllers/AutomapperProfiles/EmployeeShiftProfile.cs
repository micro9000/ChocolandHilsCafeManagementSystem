using AutoMapper;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class EmployeeShiftProfile : Profile
    {
        public EmployeeShiftProfile()
        {
            CreateMap<EmployeeShiftModel, EmployeeShiftModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
