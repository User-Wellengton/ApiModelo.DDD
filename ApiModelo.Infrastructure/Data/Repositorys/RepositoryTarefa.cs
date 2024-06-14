using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryTarefa : RepositoryBase<Tarefa>, IRepositoryTarefa
    {
        public RepositoryTarefa(MongoContext mongoContext, AutoIncrement autoIncrement)
            : base(mongoContext, autoIncrement, "tarefa")
        {
        }
    }
}
