using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(MongoContext mongoContext, AutoIncrement autoIncrement)
            : base(mongoContext, autoIncrement, "cliente")
        {
        }
    }
}
