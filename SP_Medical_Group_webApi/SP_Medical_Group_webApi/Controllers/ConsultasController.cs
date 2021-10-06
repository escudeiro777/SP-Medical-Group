using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using SP_Medical_Group_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }
        private IMedicoRepository _medicoRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            if (novaConsulta == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados inválidos"
                });
            }

            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201, new
            {
                Mensagem = "Consulta cadastarda com sucesso"
            });
        }

        [Authorize(Roles = "2")]
        [HttpPatch("Cancelar/{id}")]
        public IActionResult Cancelar(int id)
        {
            if (id < 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    Mensagem = "ID inválido"
                });
            }

            _consultaRepository.Cancelar(id);

            return StatusCode(204, new
            {
                Mensagem = "Consulta cancelada com sucesso"
            });
        }

        [Authorize(Roles = "3")]
        [HttpPatch("Descricao/{id}")]
        public IActionResult AlterarDescricao(Consultum consultaAtualizada, int id)
        {
            Consultum consultaBuscada = _consultaRepository.BuscarPorId(id);
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            int idMedico = _medicoRepository.BuscarPorId(idUsuario).IdMedico;

            if (consultaAtualizada.Descricao == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Informe a nova descrção"
                });
            }

            if (id <= 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return NotFound(new
                {
                    Mensagem = "ID inválido"
                });
            }

            if (consultaBuscada.IdMedico != idMedico)
            {
                return Unauthorized(new
                {
                    Mensagem = "Essa consulta pertence a outro médico"
                });
            }

            _consultaRepository.AlterarDescricao(consultaAtualizada.Descricao, id);

            return Ok(new
            {
                Mensagem = "Descrição da consulta alterada",
                consultaAtualizada
            });
        }

        [Authorize(Roles = "1,3")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhas()
        {
            try
            {
                int idConsulta = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                int idTipo = Convert.ToInt32(HttpContext.User.Claims.First(t => t.Type == JwtRegisteredClaimNames.Jti).Value);
                List<Consultum> listaConsultas = _consultaRepository.ListarMinhas(idConsulta, idTipo);

                if (listaConsultas.Count == 0)
                {
                    return NotFound(new
                    {
                        mensagem = "Nenhuma consulta foi encontrada"
                    });
                }
                if (idTipo == 2)
                {
                    return Ok(new
                    {
                        Mensagem = $"Esse médico tem {_consultaRepository.ListarMinhas(idConsulta, idTipo).Count} consultas",
                        listaConsultas
                    });
                }

                if (idTipo == 3)
                {
                    return Ok(new
                    {
                        Mensagem = $"Esse paciente tem {_consultaRepository.ListarMinhas(idConsulta, idTipo).Count} consultas",
                        listaConsultas
                    });
                }

                return Ok(_consultaRepository.ListarMinhas(idConsulta, idTipo));

            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            if (_consultaRepository.ListarTodos().Count == 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhuma consulta encontrada"
                });
            }

            return Ok(_consultaRepository.ListarTodos());
        }
    }
}
