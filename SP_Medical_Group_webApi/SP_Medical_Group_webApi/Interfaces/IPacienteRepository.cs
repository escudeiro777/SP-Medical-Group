using SP_Medical_Group_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
        Paciente BuscarPorId(int idPaciente);
        void Cadastrar(Paciente novoPaciente);
        void AtualizarUrl(int idPaciente, Paciente pacienteAtualizado);
        void Deletar(int idPaciente);
    }
}
