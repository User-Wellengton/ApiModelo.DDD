using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryUsuario;


        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
                : base(repositoryUsuario)
        {
            this.repositoryUsuario = repositoryUsuario;
        }

    }
}