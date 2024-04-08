using ApiModelo.Application.DTOs;

namespace ApiModelo.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDto produtoDto);
        void Update(int id , ProdutoDto produtoDto);
        void Delete(int id);
        IEnumerable<ProdutoDto> GetAll();
        ProdutoDto GetById(int id);
        ProdutoDto GetByName(string nome);
    }
}
