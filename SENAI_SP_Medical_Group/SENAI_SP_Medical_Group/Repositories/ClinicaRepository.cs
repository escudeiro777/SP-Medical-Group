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
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);
            if (clinicaBuscada != null)
            {
                clinicaBuscada.EndClinica = clinicaAtualizada.EndClinica;
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;

                ctx.Clinicas.Update(clinicaBuscada);

                ctx.SaveChanges();
            }
        }

        public Clinica BuscarPorId(short idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(u => u.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(short idClinica)
        {

            ctx.Clinicas.Remove(BuscarPorId(idClinica));
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
