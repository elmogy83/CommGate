
using AutoMapper;
using CommGate.Core.DTOs;
using CommGate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace CommGate.WebAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Correspondence, CorrespondenceVM>();
            CreateMap<ActionHistory, ActionHistoryVM>();
            CreateMap<Document, DocumentVM>();
            CreateMap<Status, StatusVM>();
            CreateMap<Purpose, PurposeVM>();
            CreateMap<Department, DepartmentVM>();
        }
    }
}
