

using ApiModelo.Application.DTOs;

namespace ApiModelo.Application.Interfaces
{
    public interface IApplicationServiceTarefa
    {
        void Add(TarefaDto tarefaDto);
        void Update(int id, TarefaDto tarefaDto);
        void Delete(int id);
        IEnumerable<TarefaDto> GetAll();
        TarefaDto GetById(int id);
        TarefaDto GetByUsuarioId(int id);
        TarefaDto GetByName(string nome);
    }
}
