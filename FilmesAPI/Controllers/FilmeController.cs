using FilmesAPI.Data;
using FilmesAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {

            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme );
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context?.Filmes?.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme filme)
        {
            var mFilme = _context?.Filmes?.FirstOrDefault(filme => filme.Id == id);
            if (mFilme == null)
            {
                return NotFound();
            }

            mFilme.Titulo = filme.Titulo;
            mFilme.Genero = filme.Genero;
            mFilme.Duracao = filme.Duracao;
            mFilme.Diretor = filme.Diretor;

            _context?.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var mFilme = _context?.Filmes?.FirstOrDefault(filme => filme.Id == id);
            if (mFilme == null)
            {
                return NotFound();
            }

            _context?.Remove(mFilme);
            _context?.SaveChanges();
            return NoContent();
        }
    }
}
