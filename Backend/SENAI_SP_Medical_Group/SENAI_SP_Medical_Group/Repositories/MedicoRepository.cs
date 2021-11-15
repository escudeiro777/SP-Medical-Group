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
    /// repositorio do medico
    /// </summary>
    public class MedicoRepository : IMedicoRepository

    {
        SpMedicalGroupContext ctx = new();
        public void AtualizarUrl(short id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);
            if (medicoBuscado!= null)
            {
                medicoBuscado.IdMedico = medicoBuscado.IdMedico;
                medicoBuscado.IdUsuario = medicoBuscado.IdUsuario;
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
                medicoBuscado.IdEspecializacao = medicoAtualizado.IdEspecializacao;
                medicoBuscado.Crm = medicoAtualizado.Crm;

                ctx.Medicos.Update(medicoBuscado);
                ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(short id)
        {
            return ctx.Medicos
               .Select(m => new Medico()
               {
                   IdMedico = m.IdMedico,
                   NomeMedico = m.NomeMedico,
                   Crm = m.Crm,
                   IdClinicaNavigation = new Clinica()
                   {
                       NomeFantasia = m.IdClinicaNavigation.NomeFantasia,
                       EndClinica = m.IdClinicaNavigation.EndClinica,
                       RazaoSocial = m.IdClinicaNavigation.RazaoSocial,
                       Cnpj = m.IdClinicaNavigation.Cnpj
                   },
                   IdEspecializacaoNavigation = new Especializacao()
                   {
                       NomeEspecializacao = m.IdEspecializacaoNavigation.NomeEspecializacao
                   },
                   Consulta = ctx.Consulta.Where(c => c.IdMedico == c.IdMedico).ToList()
               })
               .FirstOrDefault(p => p.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);
            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            Medico medicoDeletado = ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
            ctx.Medicos.Remove(medicoDeletado);
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .Select(m => new Medico()
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                    Crm = m.Crm,
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia,
                        EndClinica = m.IdClinicaNavigation.EndClinica,
                        Cnpj = m.IdClinicaNavigation.Cnpj,
                        RazaoSocial = m.IdClinicaNavigation.RazaoSocial
                    },

                    IdEspecializacaoNavigation = new Especializacao()
                    {
                        NomeEspecializacao = m.IdEspecializacaoNavigation.NomeEspecializacao
                    },
                    Consulta = ctx.Consulta.Where(c => c.IdMedico == c.IdMedico).ToList()
                })
                .ToList();
        }
    }
}
