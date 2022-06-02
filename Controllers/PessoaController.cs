using api_dependency_injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_dependency_injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        // public readonly IDb _db;
        private readonly IDb _pessoaRepository;

        public PessoaController(/*IDb dbInterface,*/ IDb pessoaRepository) // quem inicializa esse construtor? 🤔
        {
            // _db = dbInterface;
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaRepository.FindAll().OrderBy(pessoa => pessoa.Nome));
            /*var pessoasOrdenadas = _db.FindAll().OrderBy(pessoa => pessoa.Nome);
            return Ok(pessoasOrdenadas);*/
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var resultadoBusca = _pessoaRepository.Find(id);
            if (resultadoBusca == null)
            {
                return NotFound();
            }
            return Ok(resultadoBusca);
        }

        
        [HttpGet("/maiores/{idade}")]
        public IActionResult GetMaiores([FromRoute] int idade)
        {
            var pessoas = _pessoaRepository.FindAge(idade);
            if (pessoas.Count > 0)
            {
                return Ok(pessoas);
            }
            return NotFound();

        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) // erro
        {
            _pessoaRepository.Delete(id);
            return Ok();
            /*var pessoaExcluida = 
            if (pessoaExcluida != null)
            {
                return Ok(pessoaExcluida);
            }
            return NotFound();
            */
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            return Ok(_pessoaRepository.Create(pessoa.Nome, pessoa.Idade));
        }

        /*
        [HttpPut]
        public async Task<IActionResult> AsyncPut([FromBody] Pessoa pessoa)
        {
            Task<Pessoa> pessoaAtualizada = await _db.Update(pessoa);

            return Ok(pessoaAtualizada);
        }
        */
        
        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            var pessoaAtualizada = _pessoaRepository.Update(pessoa);
            if(pessoaAtualizada != null)
            {
                return Ok(pessoaAtualizada);
            }
            return NotFound();
        }
        
    }
}