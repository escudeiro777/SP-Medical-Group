using SP_Medical_Group_webApi.Contexts;
using SP_Medical_Group_webApi.Domains;
using SP_Medical_Group_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MedicalGroupSpContext ctx = new();
        public void AtualizarUrl(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            usuarioBuscado.IdTipoUsuario = usuarioBuscado.IdTipoUsuario;
            usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {

            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();

        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
               .Select(u => new Usuario()
               {
                   IdUsuario = u.IdUsuario,
                   NomeUsuario = u.NomeUsuario,
                   Email = u.Email,
                   IdTipoUsuario = u.IdTipoUsuario,
                   IdTipoUsuarioNavigation = new TipoUsuario()
                   {
                       IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                       NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                   }
               })
               .ToList();
        }
    }
}
