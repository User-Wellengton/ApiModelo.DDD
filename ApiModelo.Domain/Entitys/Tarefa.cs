
using MongoDB.Bson.Serialization.Attributes;

namespace ApiModelo.Domain.Entitys
{
    public class Tarefa : EntidadeBase
    {
        [BsonElement("nome_projeto")]
        public string NomeProjeto { get; set; }

        [BsonElement("nome_tarefa")]
        public string NomeTarefa { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }

        [BsonElement("data_inicial")]
        public DateTime DataInicial { get; set; }

        [BsonElement("data_entrega")]
        public DateTime DataEntrega { get; set; }

        [BsonElement("prioridade")]
        public int Prioridade { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }
    }
}
