using SP_Medical_Group_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodos();
        List<Consultum> ListarMinhas(int idConsulta, int idTipo);
        Consultum BuscarPorId(int idConsulta);
        void Cadastrar(Consultum novaConsulta);
        void Cancelar(int idConsulta);
        void AlterarDescricao(string novaDescricao, int idConsulta);
        void Deletar(int idConsulta);
    }
}
