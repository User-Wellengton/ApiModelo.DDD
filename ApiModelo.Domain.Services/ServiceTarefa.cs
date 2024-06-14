
using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Domain.Services
{
    public class ServiceTarefa : ServiceBase<Tarefa>, IServiceTarefa
    {
        private readonly IRepositoryTarefa repositoryTarefa;


        public ServiceTarefa(IRepositoryTarefa repositoryTarefa)
                : base(repositoryTarefa)
        {
            this.repositoryTarefa = repositoryTarefa;
        }

    }
}
