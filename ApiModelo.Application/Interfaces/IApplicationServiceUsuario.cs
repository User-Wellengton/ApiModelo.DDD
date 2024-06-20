using ApiModelo.Application.DTOs;

namespace ApiModelo.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
         void Add(UsuarioDto usuarioDto);
        void Update(int id, UsuarioDto usuarioDto);
        void Delete(int id);
        IEnumerable<UsuarioDto> GetAll();
        UsuarioDto GetById(int id);
        UsuarioDto GetByName(string nome);
    }
}
