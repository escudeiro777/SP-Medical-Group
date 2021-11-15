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
        public void AtualizarUrl(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);
            if (pacienteBuscado != null)
            {
                pacienteBuscado.IdUsuario = pacienteBuscado.IdUsuario;
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
                pacienteBuscado.DataNasc = pacienteAtualizado.DataNasc;
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;

                ctx.Pacientes.Update(pacienteBuscado);
                ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(short id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            ctx.Pacientes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes
                 .Select(p => new Paciente()
                 {
                     IdPaciente = p.IdPaciente,
                     IdUsuario = p.IdUsuario,
                     NomePaciente = p.NomePaciente,
                     Telefone = p.Telefone,
                     Cpf = p.Cpf,
                     DataNasc = p.DataNasc,
                     Endereco = p.Endereco,
                     Rg = p.Rg,
                     IdUsuarioNavigation = new Usuario()
                     {
                         Email = p.IdUsuarioNavigation.Email
                     },
                     Consulta = ctx.Consulta.Where(c => c.IdPaciente == p.IdPaciente).ToList()
                 }).ToList();
        }
    }
}
