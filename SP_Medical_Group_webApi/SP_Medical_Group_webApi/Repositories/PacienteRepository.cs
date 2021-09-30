using SP_Medical_Group_webApi.Contexts;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        MedicalGroupSpContext ctx = new();
        public void AtualizarUrl(int idPaciente, Paciente pacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
