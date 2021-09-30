using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public string EndClinica { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public TimeSpan? HoraAberto { get; set; }
        public TimeSpan? HoraFechado { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
