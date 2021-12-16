using SENAI_SP_Medical_Group.Contexts;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Repositories
{
    public class ConsultaRepository : IConsultaRepository

    {
        SpMedicalGroupContext ctx = new();
        public void AtualizarUrl(int id, Consultum consultaAtualizada)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);
            if(consultaAtualizada.IdPaciente > 0||consultaAtualizada.IdMedico > 0 ||consultaAtualizada.DataConsulta > DateTime.Now)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;

                ctx.Consulta.Update(consultaBuscada);
                ctx.SaveChanges();
            }
        }

        public Consultum BuscarPorId(short id)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            novaConsulta.Descricao = "A consulta ainda não foi realizada para ter uma descrição";
            novaConsulta.IdSituacaoConsulta= 1;
            ctx.Consulta.Add(novaConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(short id)
        {
            ctx.Consulta.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(short id, short idTipo)
        {
            switch (idTipo)
            {
                case 2:
                    Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == id);
                    short idMedico = medico.IdMedico;
                    return ctx.Consulta
                        .Select(c => new Consultum()
                        {
                            IdConsulta = c.IdConsulta,
                            DataConsulta = c.DataConsulta,
                            IdSituacaoConsulta = c.IdSituacaoConsulta,
                            IdMedico = c.IdMedico,
                            Descricao = c.Descricao,
                            IdPacienteNavigation = new Paciente()
                            {

                                NomePaciente = c.IdPacienteNavigation.NomePaciente,
                                Telefone = c.IdPacienteNavigation.Telefone,
                                Endereco = c.IdPacienteNavigation.Endereco,
                                DataNasc = c.IdPacienteNavigation.DataNasc,
                                Rg = c.IdPacienteNavigation.Rg,
                                Cpf = c.IdPacienteNavigation.Cpf
                            },
                            IdMedicoNavigation = new Medico()
                            {
                                NomeMedico = c.IdMedicoNavigation.NomeMedico,
                                Crm = c.IdMedicoNavigation.Crm,
                                IdEspecializacao = c.IdMedicoNavigation.IdEspecializacao
                            }
                        })
                        .Where(c => c.IdMedico == idMedico).ToList();
                case 3:
                    Paciente paciente = ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
                    int idPaciente =paciente.IdPaciente;
                    return ctx.Consulta
                        .Select(c => new Consultum()
                        {
                            IdPaciente = c.IdPaciente,
                            IdConsulta = c.IdConsulta,
                            DataConsulta = c.DataConsulta,
                            IdSituacaoConsulta = c.IdSituacaoConsulta,
                            IdMedico = c.IdMedico,
                            Descricao = c.Descricao,
                            IdMedicoNavigation = new Medico()
                            {
                                NomeMedico = c.IdMedicoNavigation.NomeMedico,
                                Crm = c.IdMedicoNavigation.Crm,
                                IdEspecializacao = c.IdMedicoNavigation.IdEspecializacao
                            },
                            IdPacienteNavigation = new Paciente()
                            {

                                NomePaciente = c.IdPacienteNavigation.NomePaciente,
                                Telefone = c.IdPacienteNavigation.Telefone,
                                Endereco = c.IdPacienteNavigation.Endereco,
                                DataNasc = c.IdPacienteNavigation.DataNasc,
                                Rg = c.IdPacienteNavigation.Rg,
                                Cpf = c.IdPacienteNavigation.Cpf
                            }
                        })
                        .Where(c => c.IdPaciente == idPaciente).ToList();

                default:
                    return null;

            }
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta
         .Select(p => new Consultum()
         {
             DataConsulta = p.DataConsulta,
             IdConsulta = p.IdConsulta,
             Descricao = p.Descricao,
             IdMedicoNavigation = new Medico()
             {
                 NomeMedico = p.IdMedicoNavigation.NomeMedico,
                 Crm = p.IdMedicoNavigation.Crm,
                 IdEspecializacao = p.IdMedicoNavigation.IdEspecializacao
             },
             IdPacienteNavigation = new Paciente()
             {

                 NomePaciente = p.IdPacienteNavigation.NomePaciente,
                 Telefone = p.IdPacienteNavigation.Telefone,
                 Endereco = p.IdPacienteNavigation.Endereco,
                 DataNasc = p.IdPacienteNavigation.DataNasc,
                 Rg = p.IdPacienteNavigation.Rg,
                 Cpf = p.IdPacienteNavigation.Cpf
             }
         })
             .ToList();
        }

        public void mudarDescricao(short id, string descricao)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);

            consultaBuscada.Descricao = descricao;
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public void mudarSituacao(short idConsulta, short idSituacao)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();

        }
    }
}
