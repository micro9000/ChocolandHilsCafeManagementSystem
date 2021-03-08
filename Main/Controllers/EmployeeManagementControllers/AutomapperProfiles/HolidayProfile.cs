using AutoMapper;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.AutomapperProfiles
{
    public class HolidayProfile : Profile
    {
        public HolidayProfile()
        {
            CreateMap<HolidayModel, HolidayModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
