using MongoDB.Driver;

namespace ApiModelo.Infrastructure.Data
{
    public class MongoContext 
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        // Método genérico para obter uma coleção específica
        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name + "s"); // Assuming plural form for collection names
        }
    }
}
