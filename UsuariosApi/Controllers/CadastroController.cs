using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController: ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto createDto)
        {
            Result result = _cadastroService.CadastraUsuario(createDto);
            if (result.IsFailed) return StatusCode(500);
            return Ok(result.Reasons);
        }
    }
}
