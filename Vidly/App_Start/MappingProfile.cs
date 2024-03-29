﻿using AutoMapper;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c=>c.Id, opt=>opt.Ignore());

            //o atributo pk não pode ser modificado, então é preciso informar que é para ser ignorado no mapeamento

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}