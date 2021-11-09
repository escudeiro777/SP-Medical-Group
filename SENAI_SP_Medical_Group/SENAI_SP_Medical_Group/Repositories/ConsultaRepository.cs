using SENAI_SP_Medical_Group.Contexts;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Repositories
{
    public class ConsultaRepository : IConsultaRepository

    {
        SpMedicalGroupContext ctx = new();
        public void AtualizarUrl(short id, Consultum consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consultum BuscarPorId(short id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(short id)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarMinhas(short id, short idTipo)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void mudarDescricao(short id, string descricao)
        {
            throw new NotImplementedException();
        }

        public void mudarSituacao(short idConsulta, short idSituacao)
        {
            throw new NotImplementedException();
        }
    }
}
