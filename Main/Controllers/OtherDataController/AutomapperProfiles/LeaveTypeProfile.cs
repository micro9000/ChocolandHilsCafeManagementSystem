using AutoMapper;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.AutomapperProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeModel, LeaveTypeModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
