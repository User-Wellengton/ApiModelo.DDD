
using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Entitys;
using AutoMapper;

namespace ApiModelo.Application
{
    public class ApplicationsServiceTarefa : IApplicationServiceTarefa
    {
        private readonly IServiceTarefa serviceTarefa;
        private readonly IMapper mapper;

        public ApplicationsServiceTarefa(IServiceTarefa serviceTarefa, IMapper mapper)
        {
            this.serviceTarefa = serviceTarefa;
            this.mapper = mapper;
        }

        public void Add(TarefaDto tarefaDto)
        {
            var tarefa = mapper.Map<Tarefa>(tarefaDto);
            serviceTarefa.Add(tarefa);
        }

        public IEnumerable<TarefaDto> GetAll()
        {
            var tarefas = serviceTarefa.GetAll();
            var tarefasDto = mapper.Map<IEnumerable<TarefaDto>>(tarefas);
            return tarefasDto;
        }

        public TarefaDto GetById(int id)
        {
            var tarefa = serviceTarefa.GetById(id);
            var tarefaDto = mapper.Map<TarefaDto>(tarefa);
            return tarefaDto;
        }

        public TarefaDto GetByName(string nome)
        {
            var tarefa = serviceTarefa.GetByName(nome);
            var tarefaDto = mapper.Map<TarefaDto>(tarefa);
            return tarefaDto;
        }

        public void Delete(int id)
        {
            var produto = serviceTarefa.GetById(id);
            serviceTarefa.Delete(produto);
        }

        public void Update(int id, TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = mapper.Map<Tarefa>(tarefaDto);
                tarefa.Id = id;

                var tarefaExistente = serviceTarefa.GetById(id);
                tarefa._Id = tarefaExistente._Id;
                tarefa.DataCadastro = tarefaExistente.DataCadastro;
                tarefa.DataAtualizacao = DateTime.UtcNow;

                serviceTarefa.Update(tarefa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a tarefa.", ex);
            }
        }
    }
}
