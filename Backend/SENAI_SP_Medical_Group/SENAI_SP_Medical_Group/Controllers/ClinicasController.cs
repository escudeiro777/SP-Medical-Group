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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<Clinica> listaClinicas = _clinicaRepository.ListarTodos();

            if (listaClinicas == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhuma clínica encontrada"
                });

            }
            return Ok(listaClinicas);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("deletar/{idClinica}")]
        public IActionResult Deletar(short idClinica)
        {
            _clinicaRepository.Deletar(idClinica);

            return Ok();
        }
    }
}
