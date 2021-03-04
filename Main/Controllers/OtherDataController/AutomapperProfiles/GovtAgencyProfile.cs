using AutoMapper;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.AutomapperProfiles
{
    public class GovtAgencyProfile : Profile
    {
        public GovtAgencyProfile()
        {
            CreateMap<GovernmentAgencyModel, GovernmentAgencyModel>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
