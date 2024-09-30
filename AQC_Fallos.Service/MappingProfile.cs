using AQC_Fallos.Data.Entities;
using AQC_Fallos.Service.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC_Fallos.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Falla, FallaModel>();
            CreateMap<FallaModel, Falla>();

        }
    }
}
