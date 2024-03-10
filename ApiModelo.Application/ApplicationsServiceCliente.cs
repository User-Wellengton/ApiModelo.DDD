using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application
{
    public class ApplicationsServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapper mapper;

        public ApplicationsServiceCliente(IMapper mapper, IServiceCliente serviceCliente)
        {
            this.mapper = mapper;
            this.serviceCliente = serviceCliente;
        }       
        public void Add(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteDto> GetAll()
        {
            var clientes = serviceCliente.GetAll();
            var clientesDto = mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return clientesDto;
        }

        public ClienteDto GetById(int id)
        {
            var cliente = serviceCliente.GetById(id);
            var clienteDto = mapper.Map<ClienteDto>(cliente);

            return clienteDto;
        }

        public void Delete(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Delete(cliente);
        }

        public void Update(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Update(cliente);
        }
    }
}
