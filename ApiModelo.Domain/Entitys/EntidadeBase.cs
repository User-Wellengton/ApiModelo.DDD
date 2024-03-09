using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public abstract class EntidadeBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [BsonElement("data_atualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        protected EntidadeBase()
        {
            Id = ObjectId.GenerateNewId().ToString(); 
            DataCadastro = DateTime.UtcNow;
        }

        public void AtualizarDataAtualizacao()
        {
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}

