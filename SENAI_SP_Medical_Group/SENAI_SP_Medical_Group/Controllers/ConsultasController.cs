using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            try
            {
                if (novaConsulta.IdPaciente <= 0 || novaConsulta.IdMedico <= 0 || novaConsulta.Descricao == null || novaConsulta.IdSituacaoConsulta <= 0 && novaConsulta.IdSituacaoConsulta > 3 || novaConsulta.DataConsulta < DateTime.Now)
                {
                    return BadRequest(new
                    {
                        mensagem = "Dados incorretos ou nâo informados"
                    });
                }
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);

            }

        }

       // [Authorize(Roles = "2,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                short id = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                short idTipo = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                List<Consultum> listaConsulta = _consultaRepository.ListarMinhas(id, idTipo);
                if (listaConsulta.Count == 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Vcoê não possui consultas"
                    });
                }
                return Ok(listaConsulta);
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Não foi possível localizar consultas",
                    erro
                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{id}")]
        public IActionResult MudarDescricao(short id, Consultum novaDescricao)
        {
            try
            {
                Consultum consultaBuscada = _consultaRepository.BuscarPorId(id);
                short idMedico = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                if (consultaBuscada.IdMedico != idMedico)
                {
                    return BadRequest(new
                    {
                        mensagem = "Somente o médico possuinte da consulta pode realizar alterações"
                    });
                }
                if (id <= 0)
                {

                    return BadRequest(new
                    {
                        Mensagem = "ID Inválido"
                    });
                }

                if (novaDescricao.Descricao == null)
                {

                    return BadRequest(new
                    {
                        Mensagem = "Insira a nova descrição"
                    });
                }
                _consultaRepository.mudarDescricao(id, novaDescricao.Descricao);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(short id)
        {

            if (_consultaRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "Essa consulta não existe!"
                });
            }
            return Ok(_consultaRepository.BuscarPorId(id));
        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarUrl(short id, Consultum consultaAtualizada)
        {
            _consultaRepository.AtualizarUrl(Convert.ToInt16(id), consultaAtualizada);

            return StatusCode(204);
        }

        //[Authorize(Roles = "1")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(short id)
        {

            if (_consultaRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "ID inexistente"
                });
            }
            _consultaRepository.Deletar(id);

            return StatusCode(204);
        }

        //[Authorize(Roles = "1")]
        [HttpPatch("Situacao/{id}")]
        public IActionResult MudarSituacao(short id, Consultum novaSituacao)
        {
            try
            {
                if (id <= 0)
                {

                    return BadRequest(new
                    {
                        Mensagem = "ID inválido"
                    });
                }

                if (novaSituacao.IdSituacaoConsulta <= 0)
                {

                    return BadRequest(new
                    {
                        Mensagem = "Informe um ID válido"
                    });
                }
                _consultaRepository.mudarSituacao(id, Convert.ToInt16(novaSituacao.IdSituacaoConsulta));
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
    
}
