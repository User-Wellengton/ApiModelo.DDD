using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(MongoContext mongoContext, AutoIncrement autoIncrement)
            : base(mongoContext, autoIncrement, "usuario")
        {
        }
    }
}
