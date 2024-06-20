using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application
{
    public class ApplicationsServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario serviceUsuario;
        private readonly IMapper mapper;

        public ApplicationsServiceUsuario(IServiceUsuario serviceUsuario, IMapper mapper)
        {
            this.serviceUsuario = serviceUsuario;
            this.mapper = mapper;
        }

        public void Add(UsuarioDto usuarioDto)
        {
            var usuario = mapper.Map<Usuario>(usuarioDto);
            serviceUsuario.Add(usuario);
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var usuarios = serviceUsuario.GetAll();
            var usuarioDto = mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return usuarioDto;
        }

        public UsuarioDto GetById(int id)
        {
            var usuario = serviceUsuario.GetById(id);
            var usuarioDto = mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public UsuarioDto GetByName(string nome)
        {
            var campoPesquisa = "nome";
            var usuario = serviceUsuario.GetByName(campoPesquisa, nome);
            var usuarioDto = mapper.Map<UsuarioDto>(usuario);
            return usuarioDto;
        }

        public void Delete(int id)
        {
            var usuario = serviceUsuario.GetById(id);
            serviceUsuario.Delete(usuario);
        }

        public void Update(int id, UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = mapper.Map<Usuario>(usuarioDto);
                usuario.Id = id;

                var usuarioExistente = serviceUsuario.GetById(id);
                usuario._Id = usuarioExistente._Id;
                usuario.DataCadastro = usuarioExistente.DataCadastro;
                usuario.DataAtualizacao = DateTime.UtcNow;

                serviceUsuario.Update(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o usuário.", ex);
            }
        }
    }
}
