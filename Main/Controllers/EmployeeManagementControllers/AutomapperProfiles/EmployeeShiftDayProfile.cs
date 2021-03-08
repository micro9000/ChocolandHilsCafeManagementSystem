using AutoMapper;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class EmployeeShiftDayProfile : Profile
    {
        public EmployeeShiftDayProfile()
        {
            CreateMap<EmployeeShiftDayModel, EmployeeShiftDayModel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ShiftId, opt => opt.Ignore());
        }
    }
}
