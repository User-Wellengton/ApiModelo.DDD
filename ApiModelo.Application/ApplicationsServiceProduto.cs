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

        public ProdutoDto GetByName(string nome)
        {
            var campoPesquisa = "nome";
            var produto = serviceProduto.GetByName(campoPesquisa, nome);
            var produtoDto = mapper.Map<ProdutoDto>(produto);
            return produtoDto;
        }

        public void Delete(int id)
        {
            var produto = serviceProduto.GetById(id);
            serviceProduto.Delete(produto);
        }

        public void Update(int id, ProdutoDto produtoDto)
        {
            try
            {
                var produto = mapper.Map<Produto>(produtoDto);
                produto.Id = id;

                var produtoExistente = serviceProduto.GetById(id);
                produto._Id = produtoExistente._Id;
                produto.DataCadastro = produtoExistente.DataCadastro;
                produto.DataAtualizacao = DateTime.UtcNow;

                serviceProduto.Update(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto.", ex);
            }
        }
    }
}
