using ApiModelo.Domain.Core.Interfaces.Repositorys;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        public RepositoryBase(MongoContext mongoContext)
        {
            _collection = mongoContext.GetCollection<TEntity>();
        }

        public void Add(TEntity entity)
        {
            try
            {
                _collection.InsertOne(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar entidade ao MongoDB.", ex);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                var filter = Builders<TEntity>.Filter.Eq("_id", GetIdValue(entity));
                _collection.ReplaceOne(filter, entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar entidade do MongoDB.", ex);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _collection.Find(_ => true).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todas as entidades do MongoDB.", ex);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                var filter = Builders<TEntity>.Filter.Eq("_id", id);
                return _collection.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter entidade por ID do MongoDB.", ex);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                var filter = Builders<TEntity>.Filter.Eq("_id", GetIdValue(entity));
                _collection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir entidade do MongoDB.", ex);
            }
        }

        private ObjectId GetIdValue(TEntity entity)
        {
            var propertyInfo = typeof(TEntity).GetProperty("Id");
            return (ObjectId)propertyInfo.GetValue(entity);
        }

    }
}
