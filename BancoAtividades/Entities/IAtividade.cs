namespace BancoAtividades.Entities
{
    public interface IAtividade
    {
        public int id { get; set; }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string local { get; set; }
        public int quantidadeMediadores { get; set; }
        public int faixaEtaria { get; set; }

        // ["0-5", "6-12", "13-18", "19-60", "60+"] idades de 1 a 5
        public string necResponsavel { get; set; }
        public string tipoVisita { get; set; }
        public string necTecnologiaMed { get; set; }
        public string necTecnologiaVisitante { get; set; }
        public string possibilidadeTrocaMeioOnlineOuPresencial { get; set; }
        public string acessibilidadeMotor { get; set; }
        public string acessibilidadeVisual { get; set; }
        public string accessibilidadeAuditiva { get; set; }
        public bool cienciasHumanas { get; set; }
        public bool cienciasNaturezaEMatematica { get; set; }
        public string participacaoPublico { get; set; }
    }


}
