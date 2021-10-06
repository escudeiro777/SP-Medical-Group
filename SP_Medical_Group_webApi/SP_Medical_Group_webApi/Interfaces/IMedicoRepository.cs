using SP_Medical_Group_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        Medico BuscarPorId(int idMedico);
        void Cadastrar(Medico novoMedico);
        void AtualizarUrl(int idMedico, Medico medicoAtualizado);
        void Deletar(int idMedico);
    }
}
