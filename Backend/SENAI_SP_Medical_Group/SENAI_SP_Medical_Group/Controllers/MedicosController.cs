using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using SENAI_SP_Medical_Group.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }
        private IUsuarioRepository _usuarioRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(short id)
        {
            if (_medicoRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "ID inválido"
                });
            }
            return Ok(_medicoRepository.BuscarPorId(id));
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_medicoRepository.ListarTodos());

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult AtualizarUrl(short id, Medico medicoAtualizado)
        {
            try
            {
                _medicoRepository.AtualizarUrl(Convert.ToInt16(id), medicoAtualizado);
                return StatusCode(200, new
                {
                    mensagem = "Dados atualizados!"
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(short id)
        {
            if (_medicoRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "ID inexistente!"
                });
            }
            _medicoRepository.Deletar(id);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                if (_medicoRepository.BuscarPorId(Convert.ToInt16(novoMedico.IdUsuario)) != null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Um médico já possui esse ID"
                    });
                }
                if (novoMedico.NomeMedico == null || novoMedico.IdEspecializacao == null || novoMedico.Crm == null || novoMedico.IdClinica == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Dados inválidos ou incorretos"
                    });
                }
                _medicoRepository.Cadastrar(novoMedico);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
