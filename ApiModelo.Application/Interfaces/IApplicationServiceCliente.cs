using ApiModelo.Application.DTOs;

namespace ApiModelo.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteDto clienteDto);
        void Update(int id ,ClienteDto clienteDto);
        void Delete(int id);
        IEnumerable<ClienteDto> GetAll();
        ClienteDto GetById(int id);
        ClienteDto GetByName(string nome);
    }
}
