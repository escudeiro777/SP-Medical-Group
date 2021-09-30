using SP_Medical_Group_webApi.Contexts;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        MedicalGroupSpContext ctx = new();
        public void AlterarDescricao(string novaDescricao, int idConsulta)
        {
            Consultum consultaBuscada = BuscarPorId(idConsulta);
            consultaBuscada.Descricao = novaDescricao;
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {

            novaConsulta.IdSituacaoConsulta = 1;

            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Cancelar(int idConsulta)
        {

            Consultum consultaBuscada = BuscarPorId(idConsulta);

            consultaBuscada.IdSituacaoConsulta = 3;
            consultaBuscada.Descricao = "Consulta cancelada";

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            ctx.Consulta.Remove(BuscarPorId(idConsulta));

            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int idConsulta, int idTipo)
        {
            if (idTipo == 2)
            {
                Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == idTipo);
                int idMedico = medicoBuscado.IdMedico;

                return ctx.Consulta.Where(m => m.IdMedico == idMedico).Select(c => new Consultum()
                {
                    DataConsulta = c.DataConsulta,
                    IdConsulta = c.IdConsulta,
                    Descricao = c.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Crm = c.IdMedicoNavigation.Crm,
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email

                        }
                    },

                    IdPacienteNavigation = new Paciente()
                    {
                        Cpf = c.IdPacienteNavigation.Cpf,
                        Telefone = c.IdPacienteNavigation.Telefone,
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email
                        }
                    },
                    IdSituacaoConsultaNavigation = new SituacaoConsultum
                    {
                        SituacaoConsulta = c.IdSituacaoConsultaNavigation.SituacaoConsulta

                    }

                })
                    .ToList();
            }

            else if(idTipo == 1)
            {
                int idPaciente = pacienteBuscada.IdPaciente;
                Paciente pacienteBuscada = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
                
            }
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta
                 .Select(c => new Consultum()
                 {
                     DataConsulta = c.DataConsulta,
                     IdConsulta = c.IdConsulta,
                     IdMedicoNavigation = new Medico()
                     {
                         Crm = c.IdMedicoNavigation.Crm,
                         IdUsuarioNavigation = new Usuario()
                         {
                             NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                             Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                         }
                     },
                     IdPacienteNavigation = new Paciente()
                     {
                         Cpf = c.IdPacienteNavigation.Cpf,
                         Telefone = c.IdPacienteNavigation.Telefone,
                         IdUsuarioNavigation = new Usuario()
                         {
                             NomeUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                             Email = c.IdPacienteNavigation.IdUsuarioNavigation.Email
                         }
                     },
                     IdSituacaoConsultaNavigation = new SituacaoConsultum
                     {
                         SituacaoConsulta = c.IdSituacaoConsultaNavigation.SituacaoConsulta
                     }
                 })
                 .ToList();
            
        }
    }
}
