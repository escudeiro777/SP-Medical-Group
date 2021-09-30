using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group_webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public short? IdClinica { get; set; }
        public byte? IdEspecializacao { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especializacao IdEspecializacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
