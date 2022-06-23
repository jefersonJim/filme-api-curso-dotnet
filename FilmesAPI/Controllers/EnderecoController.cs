using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Add(endereco);
            _context.SaveChanges();
            ReadEnderecoDto readEndereco = _mapper.Map<ReadEnderecoDto>(endereco);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, readEndereco);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            return Ok(_mapper.Map<ReadEnderecoDto[]>(_context.Enderecos));
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(readEnderecoDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(item => item.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
