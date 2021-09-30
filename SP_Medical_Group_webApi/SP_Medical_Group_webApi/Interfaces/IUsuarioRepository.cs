using SP_Medical_Group_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void AtualizarUrl(int idUsuario, Usuario usuarioAtualizado);

        void Deletar(int idUsuario);
    }
}
