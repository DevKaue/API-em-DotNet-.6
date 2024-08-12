using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MP.APICOMPRAS.Application.DTOs;
using MP.APICOMPRAS.Domain.Entities;

namespace MP.APICOMPRAS.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
        }
    }
}