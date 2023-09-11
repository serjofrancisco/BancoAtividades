using BancoAtividades.Entities;

namespace BancoAtividades.Repositories
{
    public interface IAtividadesRepository
    {
        Task<IEnumerable<IAtividadeReturn>> GetAllAtividades();
        Task<IAtividadeReturn> GetAtividade(int id);

        Task AddAtividade(IAtividadeReturn item);

        Task DeleteAtividade(int id);

        Task DeleteAll();

        Task<IAtividadeReturn> UpdateAtividade(int id, IAtividadeReturn item);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadeByNome(string nome);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadeByFaixaEtaria(int faixaEtaria);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByMediadores(int quantidadeMediadores);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeMotor(int acessibilidadeMotor);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeVisual(int acessibilidadeVisual);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeAuditiva(int acessibilidadeAuditiva);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasHumanas(bool cienciasHumanas);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasNaturezaEMatematica(bool cienciasNaturezaEMatematica);

        Task<IEnumerable<IAtividadeReturn>> GetAtividadesByLocal(string local);
        Task<IEnumerable<IAtividadeReturn>> GetAtividadeByMultipleFilters(string? nome = "", int? faixaEtaria = 0, int quantidadeMediadores = 0, int acessibilidadeMotor = 0, int acessibilidadeVisual = 0, int acessibilidadeAuditiva = 0, string? local = "");
    }
}
