using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Request;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;   
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest loginRequest)
        {
            Result result = _loginService.LogaUsuario(loginRequest);
            if (result.IsFailed) return Unauthorized(result.Reasons);
            return Ok(result.Reasons);
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result result = _loginService.SolicitaResetSenhaUsuario(request);
            if(result.IsFailed) return Unauthorized(result.Reasons);
            return Ok(result.Reasons);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            Result result = _loginService.ResetaSenhaUsuario(request);
            if (result.IsFailed) return Unauthorized(result.Reasons);
            return Ok(result.Reasons);
        }

    }
}
