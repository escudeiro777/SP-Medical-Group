using Microsoft.EntityFrameworkCore;
using SP_Medical_Group_webApi.Contexts;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        MedicalGroupSpContext ctx = new();

        public void AtualizarUrl(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            medicoBuscado.IdUsuario = medicoBuscado.IdUsuario;
            medicoBuscado.IdEspecializacao = medicoAtualizado.IdEspecializacao;
            medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
            medicoBuscado.Crm = medicoAtualizado.Crm;

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int idMedico)
        {

            return ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(idMedico));

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .Include(m => m.IdClinicaNavigation)
                .Include(m => m.IdEspecializacaoNavigation)
                .Include(m => m.IdUsuarioNavigation)
                .ToList();
        }
    }
}
