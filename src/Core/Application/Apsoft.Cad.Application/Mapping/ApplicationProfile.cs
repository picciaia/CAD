using Apsoft.Cad.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsoft.Cad.Application.Mapping;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Message, MessageReadModel>();
    }
}