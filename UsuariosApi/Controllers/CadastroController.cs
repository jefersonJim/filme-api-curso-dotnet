using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController: ControllerBase
    {
        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto createDto)
        {
            //TODO chamar service
            return Ok();
        }
    }
}
