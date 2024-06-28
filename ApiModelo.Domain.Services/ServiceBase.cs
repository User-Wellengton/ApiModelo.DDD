using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;

namespace ApiModelo.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        } 
        public TEntity GetByUsuarioId(int id)
        {
            return repository.GetByUsuarioId(id);
        }   
        public TEntity GetByName(string campoPesquisa ,string nome)
        {
            return repository.GetByName(campoPesquisa , nome);
        }       
    }
}
