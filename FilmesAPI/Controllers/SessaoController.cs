using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController: ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService service)
        {
            _sessaoService = service;

        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
        {

            ReadSessaoDto readDto = _sessaoService.AdicionarSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto? readDto = _sessaoService.RecuperaSessaoPorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

    }
}
