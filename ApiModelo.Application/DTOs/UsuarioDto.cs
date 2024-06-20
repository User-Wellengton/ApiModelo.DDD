using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Application.DTOs
{
    public class UsuarioDto
    {
        [BsonElement("id")]
        public int? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
