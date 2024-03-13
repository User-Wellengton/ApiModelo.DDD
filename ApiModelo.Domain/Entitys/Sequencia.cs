using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public class Sequencia
    {
        [BsonId]
        [BsonElement("nome_entidade")]
        public string EntityName { get; set; }

        [BsonElement("valor")]
        public int Valor { get; set; }
    }
}
