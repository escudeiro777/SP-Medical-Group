using SP_Medical_Group_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> ListarTodos();
        Clinica BuscarPorId(int idClinica);

        void Cadastrar(Clinica novaClinica);

        void AtualizarUrl(int idClinica, Clinica clinicaAtualizada);

        void Deletar(int idClinica);
    }
}
