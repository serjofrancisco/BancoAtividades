using BancoAtividades.Context;
using BancoAtividades.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using BancoAtividades.Utilities;

namespace BancoAtividades.Repositories
{
    public class AtividadesRepository : IAtividadesRepository
    {
        public readonly IAtividadesContext _context;

        public AtividadesRepository(IAtividadesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAllAtividades()
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();
            return atividades;
        }

        public Task<IAtividadeReturn> GetAtividade(int id)
        {
            var filter = Builders<IAtividadeReturn>.Filter.Eq(m => m.id, id);
            var result = _context.Atividades.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task AddAtividade(IAtividadeReturn item)
        {
            await _context.Atividades.InsertOneAsync(item);
        }

        public async Task DeleteAtividade(int id)
        {
            var filter = Builders<IAtividadeReturn>.Filter.Eq(m => m.id, id);
            await _context.Atividades.DeleteOneAsync(filter);
        }

        public async Task DeleteAll()
        {
            await _context.Atividades.DeleteManyAsync(new BsonDocument());
        }

        public async Task<IAtividadeReturn> UpdateAtividade(int id, IAtividadeReturn item)
        {
            var filter = Builders<IAtividadeReturn>.Filter.Eq(m => m.id, id);
            await _context.Atividades.ReplaceOneAsync(filter, item);
            return item;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadeByNome(string nome)
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.nome.ToLower().Contains(nome.ToLower()));

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadeByFaixaEtaria(int faixaEtaria)
        {
     
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

           
            var atividadesFiltradas = atividades.Where(atividade => atividade.faixaEtaria <= faixaEtaria);


            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByMediadores(int quantidadeMediadores)
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.quantidadeMediadores <= quantidadeMediadores);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasHumanas(bool cienciasHumanas)
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.cienciasHumanas == cienciasHumanas);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasNaturezaEMatematica(bool cienciasNaturezaEMatematica)
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.cienciasNaturezaEMatematica == cienciasNaturezaEMatematica);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeMotor(int acessibilidadeMotor)
        {
            //Colocar o nivel de acessibilidade necessária de 1-5, sendo 1 menos necessário e 5 muito necessário
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            Console.WriteLine(atividades[0].acessibilidadeMotor);
            
            var atividadesFiltradas = atividades.Where(atividade => atividade.acessibilidadeMotor >= acessibilidadeMotor);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeVisual(int acessibilidadeVisual)
        {
            //Colocar o nivel de acessibilidade necessária de 1-5, sendo 1 menos necessário e 5 muito necessário
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.acessibilidadeVisual >= acessibilidadeVisual);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeAuditiva(int acessibilidadeAuditiva)
        {
            //Colocar o nivel de acessibilidade necessária de 1-5, sendo 1 menos necessário e 5 muito necessário
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.acessibilidadeAuditiva >= acessibilidadeAuditiva);

            return atividadesFiltradas;
        }

        public async Task<IEnumerable<IAtividadeReturn>> GetAtividadesByLocal(string local)
        {
            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.local.ToLower().Contains(local.ToLower()));

            return atividadesFiltradas;
        }

        async public Task<IEnumerable<IAtividadeReturn>> GetAtividadeByMultipleFilters(string? nome = "", int? faixaEtaria = 0, int quantidadeMediadores = 0, int acessibilidadeMotor = 0, int acessibilidadeVisual = 0, int acessibilidadeAuditiva = 0, string? local = "")
        {

            var atividades = await _context.Atividades.Find(_ => true).ToListAsync();

            var atividadesFiltradas = atividades.Where(atividade => atividade.nome.ToLower().Contains(nome.ToLower()));

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.faixaEtaria >= faixaEtaria);

            if (quantidadeMediadores > 0)
            {
                atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.quantidadeMediadores <= quantidadeMediadores);
            }

            /*atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.cienciasHumanas == cienciasHumanas);

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.cienciasNaturezaEMatematica == cienciasNaturezaEMatematica);*/

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.acessibilidadeMotor >= acessibilidadeMotor);

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.acessibilidadeVisual >= acessibilidadeVisual);

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.acessibilidadeAuditiva >= acessibilidadeAuditiva);

            atividadesFiltradas = atividadesFiltradas.Where(atividade => atividade.local.ToLower().Contains(local.ToLower()));

            return atividadesFiltradas;
        }
    }
}
