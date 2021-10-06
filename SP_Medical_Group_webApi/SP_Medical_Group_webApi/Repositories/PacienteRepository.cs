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
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            pacienteBuscado.IdUsuario = pacienteBuscado.IdUsuario;
            pacienteBuscado.DataNasc = pacienteAtualizado.DataNasc;
            pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            pacienteBuscado.Rg = pacienteAtualizado.Rg;
            pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            pacienteBuscado.Endereco = pacienteAtualizado.Endereco;

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(BuscarPorId(idPaciente));

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
