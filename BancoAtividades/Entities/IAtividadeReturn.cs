using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BancoAtividades.Entities
{
    public class IAtividadeReturn
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int id { get; set; }     
        
        public string nome { get; set; }
        public string descricao { get; set; }
        public string local { get; set; }
        public int quantidadeMediadores { get; set; }
        public int faixaEtaria { get; set; }

        // ["0-5", "6-12", "13-18", "19-60", "60+"] idades de 1 a 5 e 0 é livre
        public string necResponsavel { get; set; }
        public string tipoVisita { get; set; }
        public int necTecnologiaMed { get; set; }
        public int necTecnologiaVisitante { get; set; }
        public string possibilidadeTrocaMeioOnlineOuPresencial { get; set; }
        public int acessibilidadeMotor { get; set; }
        public int acessibilidadeVisual { get; set; }
        public int acessibilidadeAuditiva { get; set; }
        public bool cienciasHumanas { get; set; }
        public bool cienciasNaturezaEMatematica { get; set; }
        public int participacaoPublico { get; set; }
    }
}


