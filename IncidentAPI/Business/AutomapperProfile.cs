using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTO;
using Data.Entities;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<IncidentDto, Contact>()
                .ForMember(c => c.FirstName, i => i.MapFrom(x => x.FirstName))
                .ForMember(c => c.LastName, i => i.MapFrom(x => x.LastName));

            CreateMap<IncidentDto, Incident>()
                .ForMember(i => i.Description, idto => idto.MapFrom(x => x.IncidentDescription));

        }
    }
}
