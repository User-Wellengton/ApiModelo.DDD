using ApiModelo.Application.DTOs;

namespace ApiModelo.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteDto clienteDto);
        void Update(ClienteDto clienteDto);
        void Delete(int id);
        IEnumerable<ClienteDto> GetAll();
        ClienteDto GetById(int id);
    }
}
