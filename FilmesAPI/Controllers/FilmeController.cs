using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Add(filme);
            _context.SaveChanges();
            ReadFilmeDto readFilme = _mapper.Map<ReadFilmeDto>(filme);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, readFilme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            Filme[] filmes = _context.Filmes.ToArray();
            return Ok(_mapper.Map<Filme[]>(filmes));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                ReadFilmeDto readFilme = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(readFilme);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context?.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var mFilme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
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
