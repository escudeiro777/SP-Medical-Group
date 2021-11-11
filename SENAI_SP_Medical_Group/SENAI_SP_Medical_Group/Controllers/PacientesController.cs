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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(short id)
        {
            if (_pacienteRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "ID inexistente!"
                });
            }
            return Ok(_pacienteRepository.BuscarPorId(id));
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_pacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
               return BadRequest(erro);
            }
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarUrl(short id, Paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.AtualizarUrl(Convert.ToInt16(id), pacienteAtualizado);
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

        [HttpDelete("deletar/{id}")]
        public IActionResult Deletar(short id)
        {
            if (_pacienteRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    mensagem = "ID inexistente"
                });
            }
            _pacienteRepository.Deletar(id);

            return StatusCode(204);
        }
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            try
            {
                if (_pacienteRepository.BuscarPorId(Convert.ToInt16(novoPaciente.IdUsuario)) != null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Um paciente já possui esse ID"
                    });
                }
                if (novoPaciente.NomePaciente == null || novoPaciente.Telefone == null || novoPaciente.Endereco == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "Dados inválidos ou incorretos"
                    });
                }
                _pacienteRepository.Cadastrar(novoPaciente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
