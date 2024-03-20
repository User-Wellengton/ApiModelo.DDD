using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Application.DTOs
{
    public class ProdutoDto
    {
        [BsonElement("id")]
        public int? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("valor")]
        public decimal Valor { get; set; }

        [BsonElement("disponivel")]
        public bool Disponivel { get; set; }
    }
}
