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
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readCinema = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readCinema.Id }, readCinema);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas()
        {
            List<ReadCinemaDto> cinemas = _cinemaService.RecuperaCinemas();
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto? cinema = _cinemaService.RecuperaCinemasPorId(id);
            if (cinema != null)
            {
                return Ok(cinema);
            }
            
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.AtualizaCinema(id, cinemaDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = _cinemaService.DeletaCinema(id);
            if (result.IsFailed) return NotFound();   
            return NoContent();
        }

    }
}
