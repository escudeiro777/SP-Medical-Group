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
    /// repositorio da clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedicalGroupContext ctx = new();
        public void AtualizarUrl(short id, Clinica clinicaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(short id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            Clinica clinicaBuscada = ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
