using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI_SP_Medical_Group.Domains
{
    public partial class SituacaoConsultum
    {
        public SituacaoConsultum()
        {
            Consulta = new HashSet<Consultum>();
        }

        public byte IdSituacaoConsulta { get; set; }
        public string SituacaoConsulta { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
