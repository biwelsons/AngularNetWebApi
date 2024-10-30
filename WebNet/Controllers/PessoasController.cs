using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet.Models;

namespace WebNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PessoasController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PessoasController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAllAsync(){
            return await _context.Pessoas.ToListAsync();
        }

        [HttpGet("ativos")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAtivosAsync()
        {
            return await _context.Pessoas
                                .Where(pessoa => pessoa.Ativo == true)
                                .ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Pessoa>> CreatePessoaAsync (Pessoa pessoa){
            pessoa.Ativo = true;
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutPessoasAsync (Pessoa pessoa){
            var pessoaExistente = await _context.Pessoas.FindAsync(pessoa.PessoaId);
            if (pessoaExistente == null)
                return NotFound();

            pessoa.Ativo = pessoaExistente.Ativo;

            _context.Entry(pessoaExistente).CurrentValues.SetValues(pessoa);
            await _context.SaveChangesAsync();

            return Ok();;
        }

        [HttpDelete ("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoaAsync (int pessoaId) {
            Pessoa pessoa = await _context.Pessoas.FindAsync (pessoaId);
            if (pessoa == null)
                return NotFound ();

            pessoa.Ativo = false;
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync ();
            return Ok ();
        }

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> GetByIdAsync(int pessoaId){
            Pessoa pessoa =  await _context.Pessoas.FindAsync(pessoaId);

            if (pessoa == null) 
                return NotFound();

            return pessoa;
        }
    }
}