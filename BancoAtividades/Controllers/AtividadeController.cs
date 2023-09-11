using BancoAtividades.Entities;
using BancoAtividades.Repositories;
using BancoAtividades.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoAtividades.Controllers;
[ApiController]
[Route("atividades/[controller]")]
    public class AtividadeController : Controller
    {
      private readonly IAtividadesRepository _atividadesRepository;

      public AtividadeController(IAtividadesRepository atividadesRepository)
    {
            _atividadesRepository = atividadesRepository;
    }

    [HttpGet]
    public Task<IEnumerable<IAtividadeReturn>> Get()
    {
        return _atividadesRepository.GetAllAtividades();
    }

    [HttpGet("{id}")]
    public Task<IAtividadeReturn> Get(int id)
    {
        return _atividadesRepository.GetAtividade(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] IAtividadeReturn atividade)
    {
        await _atividadesRepository.AddAtividade(atividade);
        return new OkObjectResult(atividade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] IAtividadeReturn atividade)
    {
        var atividadeFromDb = await _atividadesRepository.GetAtividade(id);

        if (atividadeFromDb == null)
        {
            return new NotFoundResult();
        }

        atividade.id = atividadeFromDb.id;

        await _atividadesRepository.UpdateAtividade(id, atividade);

        return new OkObjectResult(atividade);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _atividadesRepository.GetAtividade(id);

        if (post == null)
        {
            return new NotFoundResult();
        }

        await _atividadesRepository.DeleteAtividade(id);

        return new OkResult();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        await _atividadesRepository.DeleteAll();
        return new OkResult();
    }

    [HttpGet("nome/{nome}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadeByNome(string nome)
    {
        return _atividadesRepository.GetAtividadeByNome(nome);
    }

    [HttpGet("faixaEtaria/{faixaEtaria}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadeByFaixaEtaria(int faixaEtaria)
    {
        //range de 0 a 5 para indicar as faixas etárias
        return _atividadesRepository.GetAtividadeByFaixaEtaria(faixaEtaria);
    }

    [HttpGet("quantidadeMediadores/{quantidadeMediadores}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByMediadores(int quantidadeMediadores)
    {
        return _atividadesRepository.GetAtividadesByMediadores(quantidadeMediadores);
    }

    [HttpGet("acessibilidadeMotor/{acessibilidadeMotor}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeMotor(int acessibilidadeMotor)
    {
        return _atividadesRepository.GetAtividadesByAcessibilidadeMotor(acessibilidadeMotor);
    }

    [HttpGet("acessibilidadeVisual/{acessibilidadeVisual}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeVisual(int acessibilidadeVisual)
    {
        return _atividadesRepository.GetAtividadesByAcessibilidadeVisual(acessibilidadeVisual);
    }

    [HttpGet("acessibilidadeAuditiva/{acessibilidadeAuditiva}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByAcessibilidadeAuditiva(int acessibilidadeAuditiva)
    {
        return _atividadesRepository.GetAtividadesByAcessibilidadeAuditiva(acessibilidadeAuditiva);
    }

    [HttpGet("cienciasHumanas/{cienciasHumanas}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasHumanas(bool cienciasHumanas)
    {
        return _atividadesRepository.GetAtividadesByCienciasHumanas(cienciasHumanas);
    }

    [HttpGet("cienciasNaturezaEMatematica/{cienciasNaturezaEMatematica}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByCienciasNaturezaEMatematica(bool cienciasNaturezaEMatematica)
    {
        return _atividadesRepository.GetAtividadesByCienciasNaturezaEMatematica(cienciasNaturezaEMatematica);
    }

    [HttpGet("local/{local}")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByLocal(string local)
    {
        return _atividadesRepository.GetAtividadesByLocal(local);
    }

    [HttpGet("filtro")]
    public Task<IEnumerable<IAtividadeReturn>> GetAtividadesByFilters([FromQuery] string? nome = "", int? faixaEtaria = 0, int quantidadeMediadores = 0, int acessibilidadeMotor = 0, int acessibilidadeVisual = 0, int acessibilidadeAuditiva = 0, string? local = "")
    {   
      
        return _atividadesRepository.GetAtividadeByMultipleFilters(nome, faixaEtaria, quantidadeMediadores, acessibilidadeMotor, acessibilidadeVisual, acessibilidadeAuditiva, local);
    }
    }
