using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group_webApi.Domains
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
