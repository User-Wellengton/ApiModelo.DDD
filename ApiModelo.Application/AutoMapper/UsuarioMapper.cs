using ApiModelo.Application.DTOs;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application.AutoMapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
