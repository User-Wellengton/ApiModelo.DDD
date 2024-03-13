using ApiModelo.Domain.Entitys;
using MongoDB.Driver;

namespace ApiModelo.Infrastructure.Data
{
    public class AutoIncrement
    {
        private readonly IMongoCollection<Sequencia> _collection;
        private readonly IMongoDatabase _database;

        public AutoIncrement(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = _database.GetCollection<Sequencia>("sequencias");
        }

        public int GetNextSequence(string entityName)
        {
            var filter = Builders<Sequencia>.Filter.Eq(x => x.EntityName, entityName);
            var update = Builders<Sequencia>.Update.Inc(x => x.Valor, 1);
            var options = new FindOneAndUpdateOptions<Sequencia>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };

            var result = _collection.FindOneAndUpdate(filter, update, options);
            
            if (result == null)
            {
                return 1;
            }

            return result.Valor;
        }
    }
}
