namespace BancoAtividades.Entities
{
    public interface IFilters
    {
        public string? nome { get; set; }
        public string? faixaEtaria { get; set; }
        public int? quantidadeMediadores { get; set; }
        public int? acessibilidadeMotor { get; set; }
        public int? acessibilidadeVisual { get; set; }
        public int? acessibilidadeAuditiva { get; set; }
        public bool? cienciasHumanas { get; set; }
        public bool? cienciasNaturezaEMatematica { get; set; }
        public string? local { get; set; }
    }

}
