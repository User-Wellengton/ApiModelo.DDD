using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;

namespace ApiModelo.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente> , IServiceCliente
    {
        private readonly IRepositoryCliente repositoryCLiente;

        public ServiceCliente(IRepositoryCliente repositoryCLiente)
            : base(repositoryCLiente) 
        {
            this.repositoryCLiente = repositoryCLiente;
        }
    }
}
