using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService service)
        {
            _enderecoService = service;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoService.AdicionarEndereco(enderecoDto);
           
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            List<ReadEnderecoDto> enderecos = _enderecoService.RecuperaEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto? readDto = _enderecoService.RecuperaEnderecoPorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoService.AtualizarEndereco(id, enderecoDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result result = _enderecoService.DeletaEndereco(id);
            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
