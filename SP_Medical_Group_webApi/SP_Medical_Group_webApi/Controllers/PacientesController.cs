using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using SP_Medical_Group_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
            private IPacienteRepository _pacienteRepository { get; set; }
            public PacientesController()
            {
                _pacienteRepository = new PacienteRepository();
            }

            //[Authorize(Roles = "1")]
            [HttpPost]
            public IActionResult Cadastrar(Paciente novoPaciente)
            {
                if (novoPaciente.IdUsuario <= 0 || novoPaciente.DataNasc > DateTime.Now)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Dados invalidos ou incompletos"
                    });
                }

                _pacienteRepository.Cadastrar(novoPaciente);

                return StatusCode(201, new
                {
                    Mensagem = "Novo paciente criado",
                    novoPaciente
                });
            }

            //[Authorize(Roles = "1")]
            [HttpGet]
            public IActionResult Listar()
            {
                List<Paciente> listaPacientes = _pacienteRepository.ListarTodos();

                if (listaPacientes == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Nenhum paciente encontrado"
                    });
                }

                return Ok(listaPacientes);
            }
       

    }
}
