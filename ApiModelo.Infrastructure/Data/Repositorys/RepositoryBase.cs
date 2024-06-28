using ApiModelo.Domain.Core.Interfaces.Repositorys;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiModelo.Infrastructure.Data.Repositorys
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly AutoIncrement _autoIncrement;

        public RepositoryBase(MongoContext mongoContext, AutoIncrement autoIncrement, string collectionName)
        {
            _collection = mongoContext.GetCollection<TEntity>(collectionName);
            _autoIncrement = autoIncrement;
        }

        public void Add(TEntity entity)
        {
            try
            {
                if (typeof(TEntity).GetProperty("Id") != null)
                {
                    var propertyInfo = typeof(TEntity).GetProperty("Id");
                    propertyInfo.SetValue(entity, _autoIncrement.GetNextSequence(typeof(TEntity).Name));
                }
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
                var filter = Builders<TEntity>.Filter.Eq("id", GetIdValue(entity));
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
                var filter = Builders<TEntity>.Filter.Eq("id", id);

                
                if (filter == null || filter == Builders<TEntity>.Filter.Empty)
                {
                    throw new ArgumentException("Não foi localizado registro com esse ID.");
                }

               
                var entity = _collection.Find(filter).FirstOrDefault();

                if (entity == null)
                {
                    throw new ArgumentException("Não foi localizado registro com esse ID.");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi localizado registro com esse ID.", ex);
            }
        } 
        
        public TEntity GetByUsuarioId(int id)
        {                    
                var filter = Builders<TEntity>.Filter.Eq("usuarioId", id);   
               
                var entity = _collection.Find(filter).FirstOrDefault();              

                return entity;             
        }

        public TEntity GetByName(string campoPesquisa , string nome)
        {
            try
            {
                var filter = Builders<TEntity>.Filter.Regex(campoPesquisa, new BsonRegularExpression(nome, "i"));


                if (filter == null || filter == Builders<TEntity>.Filter.Empty)
                {
                    throw new ArgumentException("Não foi localizado registro com esse Nome.");
                }

                
                var entity = _collection.Find(filter).FirstOrDefault();

                if (entity == null)
                {
                    throw new ArgumentException("Não foi localizado registro com esse Nome.");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi localizado registro com esse Nome.", ex);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                var filter = Builders<TEntity>.Filter.Eq("Id", GetIdValue(entity));
                _collection.DeleteOne(filter);
                _autoIncrement.AtualizarSequencia(typeof(TEntity).Name);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter entidade por ID do MongoDB.", ex);
            }
        }

        private Int32 GetIdValue(TEntity entity)
        {
            var propertyInfo = typeof(TEntity).GetProperty("Id");
            return (Int32)propertyInfo.GetValue(entity);
        }
       
    }
}
