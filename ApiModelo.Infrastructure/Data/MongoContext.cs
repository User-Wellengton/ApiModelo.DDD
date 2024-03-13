using ApiModelo.Domain.Entitys;
using ApiModelo.Infrastructure.Data;
using MongoDB.Driver;

public class MongoContext
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Sequencia> _sequenceCollection;

    public MongoContext(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
        _sequenceCollection = _database.GetCollection<Sequencia>("Sequences");
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }

    // Método para obter o próximo valor da sequência
    public int GetNextSequenceValue(string sequenceName)
    {
        var filter = Builders<Sequencia>.Filter.Eq(x => x.EntityName, sequenceName);
        var update = Builders<Sequencia>.Update.Inc(x => x.Valor, 1);
        var options = new FindOneAndUpdateOptions<Sequencia>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };

        var sequence = _sequenceCollection.FindOneAndUpdate(filter, update, options);
        return sequence.Valor;
    }
}