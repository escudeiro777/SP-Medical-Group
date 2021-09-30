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
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int idMedico)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico novaConsulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idMedico)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
