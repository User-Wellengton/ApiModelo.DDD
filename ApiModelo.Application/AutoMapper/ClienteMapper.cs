using ApiModelo.Application.DTOs;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application.AutoMapper
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
