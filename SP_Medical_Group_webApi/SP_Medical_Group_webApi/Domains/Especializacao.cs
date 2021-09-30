using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group_webApi.Domains
{
    public partial class Especializacao
    {
        public Especializacao()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecializacao { get; set; }
        public string NomeEspecializacao { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
