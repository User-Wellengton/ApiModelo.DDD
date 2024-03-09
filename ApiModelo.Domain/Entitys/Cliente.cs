using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public class Cliente : EntidadeBase
    {
        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("sobrenome")]
        public string Sobrenome { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("ativo")]
        public bool Ativo { get; set; }
    }
}
