﻿using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Request;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        internal Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new [] { usuarioIdentity.Email }, 
                    "Link de Ativação", 
                    usuarioIdentity.Id,
                    encodedCode);
                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Erro ao tentar cadastrar o usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioID);

            if (identityUser == null) return Result.Fail("Usuário inválido");
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.CodigoDeAtivavao).Result;
            if(identityResult.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao ativar conta do usuário");
        }
    }
}
