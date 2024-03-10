using ApiModelo.Application.DTOs;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application.AutoMapper
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
