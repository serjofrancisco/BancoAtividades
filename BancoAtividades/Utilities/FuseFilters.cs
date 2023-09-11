using BancoAtividades.Entities;

namespace BancoAtividades.Utilities
    
{
    public class FuseFilters
    {
        public static IFilters PutDefaults(IFilters filters) 
        {
            IFilters filters1 = new Filters();

            if (filters.nome != null)
            {
                filters1.nome = filters.nome;
            }
            if (filters.faixaEtaria != null)
            {
                filters1.faixaEtaria = filters.faixaEtaria;
            }

            if (filters.quantidadeMediadores != null)
            {
                filters1.quantidadeMediadores = filters.quantidadeMediadores;
            }

            if (filters.acessibilidadeMotor != null)
            {
                filters1.acessibilidadeMotor = filters.acessibilidadeMotor;
            }

            if (filters.acessibilidadeVisual != null)
            {
                filters1.acessibilidadeVisual = filters.acessibilidadeVisual;
            }

            if (filters.acessibilidadeAuditiva != null)
            {
                filters1.acessibilidadeAuditiva = filters.acessibilidadeAuditiva;
            }

                filters1.cienciasHumanas = filters.cienciasHumanas;
            
           
                filters1.cienciasNaturezaEMatematica = filters.cienciasNaturezaEMatematica;


            if (filters.local != null)
            {
                filters1.local = filters.local;
            }

           return filters1;
        }
    }
}
