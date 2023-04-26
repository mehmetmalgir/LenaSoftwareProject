using AutoMapper;
using LenaSoftware.API.Model.Dtos;
using LenaSoftware.API.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Bussiness.Mappers.AutoMapper
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormGetDto>()
                .ForMember(dto => dto.FullName, entity => entity.MapFrom(x => x.User.FullName))
                .ForMember(dto => dto.Name, entity => entity.MapFrom(x => x.Field.Name))
                .ForMember(dto => dto.Surname, entity => entity.MapFrom(x => x.Field.Surname))
                .ForMember(dto => dto.Age, entity => entity.MapFrom(x => x.Field.Age));

            CreateMap<FormForCreation, Form>();
                



        }

    }
}
