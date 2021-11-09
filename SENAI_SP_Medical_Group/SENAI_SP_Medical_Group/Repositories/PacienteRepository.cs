using SENAI_SP_Medical_Group.Contexts;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Repositories
{
    /// <summary>
    /// repositorio do paciente
    /// </summary>
    public class PacienteRepository : IPacienteRepository

    {
        SpMedicalGroupContext ctx = new();
        public void AtualizarUrl(short id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);
            if (pacienteBuscado != null)
            {
                pacienteBuscado.IdUsuario = pacienteBuscado.IdUsuario;
                //pacienteBusca
            }
        }

        public Paciente BuscarPorId(short id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(short idPaciente)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
