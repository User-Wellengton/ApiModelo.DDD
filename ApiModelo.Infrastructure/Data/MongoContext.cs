using MongoDB.Driver;

namespace ApiModelo.Infrastructure.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        // Método genérico para obter uma coleção específica
        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}
