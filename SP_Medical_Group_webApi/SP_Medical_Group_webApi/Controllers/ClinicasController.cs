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

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);


            return StatusCode(201, new { Mensagem = "Clinica  Cadastrada", novaClinica });

        }

        //[Authorize(Roles = "1")]
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

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int IdClinica)
        {

            return Ok(_clinicaRepository.BuscarPorId(IdClinica));

        }

        //[Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult AtualizarUrl(int idClinica, Clinica clinicaAtualizada)
        {
            try
            {
                if (idClinica <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "ID inválido"
                    });
                }
                if (_clinicaRepository.BuscarPorId(idClinica) == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Nenhuma clínica possui esse ID"
                    });
                }
                _clinicaRepository.AtualizarUrl(idClinica, clinicaAtualizada);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int idClinica)
        {
            try
            {
                if (idClinica <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "ID inválido"
                    });
                }
                if (_clinicaRepository.BuscarPorId(idClinica) == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Nenhuma clínica possui esse ID"
                    });
                }
                _clinicaRepository.Deletar(idClinica);
                return Ok(new
                {
                    Mensagem = "Clínica deletada"
                });
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }
    }
}
