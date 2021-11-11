using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using SENAI_SP_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha incorretos");
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString())
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Sp_medical_Group-chave-autenticacao"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: "Sp_medical.webAPI", audience: "Sp_medical.webAPI", claims: minhasClaims, expires: DateTime.Now.AddMinutes(30), signingCredentials: Creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token)
            });

        }
    }
}
