using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application
{
    public class ApplicationsServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto serviceProduto;
        private readonly IMapper mapper;

        public ApplicationsServiceProduto(IServiceProduto serviceProduto, IMapper mapper)
        {
            this.serviceProduto = serviceProduto;
            this.mapper = mapper;
        }

        public void Add(ProdutoDto produtoDto)
        {
            var produto = mapper.Map<Produto>(produtoDto);
            serviceProduto.Add(produto);
        }

        public IEnumerable<ProdutoDto> GetAll()
        {
            var produtos = serviceProduto.GetAll();
            var produtosDto = mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return produtosDto;
        }

        public ProdutoDto GetById(int id)
        {
            var produto = serviceProduto.GetById(id);
            var produtoDto = mapper.Map<ProdutoDto>(produto);
            return produtoDto;
        }

        public void Delete(int id)
        {
            var produto = serviceProduto.GetById(id);
            serviceProduto.Delete(produto);
        }

        public void Update(ProdutoDto produtoDto)
        {
            var produto = mapper.Map<Produto>(produtoDto);
            serviceProduto.Update(produto);
        }
    }
}
