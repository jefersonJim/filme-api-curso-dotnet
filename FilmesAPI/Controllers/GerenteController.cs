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
    public class GerenteController: ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto dto)
        {

            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {

            ReadGerenteDto? readDto = _gerenteService.RecuperaGerentePorId(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();

        }
    }
}
