using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_SP_Medical_Group.Interfaces;
using SENAI_SP_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfisController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public PerfisController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [Authorize]
        [HttpPost("imagem/bd")]
        public IActionResult PostBD(IFormFile arquivo)
        {
            try
            {
                if (arquivo.Length > 10000) //10MB
                {
                    return BadRequest(new { mensagem = "Tamanho da imagem não suportado" });
                }

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                {
                    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos" });
                }

                short idUsuario = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilBD(arquivo, idUsuario);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("imagem/bd")]
        public IActionResult getBd()
        {
            try
            {
                short idUsuario = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string base64 = _usuarioRepository.ConsultarPerfilBD(idUsuario);
                return Ok(base64);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

