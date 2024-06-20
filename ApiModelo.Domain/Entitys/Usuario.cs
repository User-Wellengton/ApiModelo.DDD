using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public class Usuario : EntidadeBase
    {
        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
