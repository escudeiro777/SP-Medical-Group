using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SP_Medical_Group.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public short? IdMedico { get; set; }
        public byte? IdSituacaoConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual SituacaoConsultum IdSituacaoConsultaNavigation { get; set; }
    }
}
