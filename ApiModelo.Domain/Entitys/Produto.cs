using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public class Produto : EntidadeBase
    {
        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("valor")]
        public decimal Valor { get; set; }

        [BsonElement("disponivel")]
        public bool Disponivel { get; set; }
    }
}
