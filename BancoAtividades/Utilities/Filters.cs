using BancoAtividades.Entities;

namespace BancoAtividades.Utilities
{
    public class Filters : IFilters
    {
        public Filters(string nome = "", string faixaEtaria = "", int quantidadeMediadores = 0, int acessibilidadeMotor = 0, int acessibilidadeVisual = 0, int acessibilidadeAuditiva = 0, bool cienciasHumanas = true, bool cienciasNaturezaEMatematica = true, string local = "")
        {
            this.nome = nome;
            this.faixaEtaria = faixaEtaria;
            this.quantidadeMediadores = quantidadeMediadores;
            this.acessibilidadeMotor = acessibilidadeMotor;
            this.acessibilidadeVisual = acessibilidadeVisual;
            this.acessibilidadeAuditiva = acessibilidadeAuditiva;
            this.cienciasHumanas = cienciasHumanas;
            this.cienciasNaturezaEMatematica = cienciasNaturezaEMatematica;
            this.local = local;

        }

        public string? nome { get; set; } = string.Empty;
        public string? faixaEtaria { get; set; } = string.Empty;
        public int? quantidadeMediadores { get; set; } = 0;

        public int? acessibilidadeMotor { get; set; } = 0;
        public int? acessibilidadeVisual { get; set; } = 0;
        public int? acessibilidadeAuditiva { get; set; } = 0;
        public bool? cienciasHumanas { get; set; } = false;
        public bool? cienciasNaturezaEMatematica { get; set; } = false;
        public string? local { get; set; } = string.Empty;
    }
}
