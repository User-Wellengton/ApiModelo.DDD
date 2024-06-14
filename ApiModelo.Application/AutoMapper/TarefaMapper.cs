
using ApiModelo.Application.DTOs;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application.AutoMapper
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<Tarefa, TarefaDto>().ReverseMap();
        }
    }
}
