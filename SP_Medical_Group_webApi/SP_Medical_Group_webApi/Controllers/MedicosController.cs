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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        //    [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            if (novoMedico.IdUsuario <= 0 || novoMedico.IdEspecializacao <= 0 || novoMedico.IdClinica <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados inválidos"
                });
            }

            _medicoRepository.Cadastrar(novoMedico);

            return Ok(new
            {
                Mensagem = "Médico cadastrado",
                novoMedico
            });
        }

        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            if (_medicoRepository.ListarTodos().Count <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Médico não encontrado"
                });
            }

            return Ok(_medicoRepository.ListarTodos());
        }
    }
}
