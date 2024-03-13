using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        public RepositoryProduto(MongoContext mongoContext, AutoIncrement autoIncrement)
            : base(mongoContext, autoIncrement, "produto")
        {
        }        
    }
}