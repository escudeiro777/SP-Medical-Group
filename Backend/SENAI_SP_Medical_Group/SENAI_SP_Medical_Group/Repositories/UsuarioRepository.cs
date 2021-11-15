using Microsoft.AspNetCore.Http;
using SENAI_SP_Medical_Group.Contexts;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Repositories
{
    /// <summary>
    /// repositorio do usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGroupContext ctx = new();
        public Usuario BuscarPorId(short id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public string ConsultarPerfilBD(short idUsuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();
            imagemUsuario = ctx.ImagemUsuarios.FirstOrDefault(iu => iu.IdUsuario == idUsuario);
            if (imagemUsuario != null)
            {
                return Convert.ToBase64String(imagemUsuario.Binario);
            }
            return null;
        }
 
        public void Deletar(short id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioBuscado == null)
            {
                throw new Exception("ID de usuário inexistente");
            }
            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilBD(IFormFile foto, short idUsuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();
            using (var ms = new MemoryStream())
            {
                //copia a imagem que foi enviada para a memoria
                foto.CopyTo(ms);

                imagemUsuario.Binario = ms.ToArray();

                //nome do arquivo
                imagemUsuario.NomeArquivo = foto.FileName;

                //estensao do arquivo
                imagemUsuario.MimeType = foto.FileName.Split('.').Last();

                //ID do usuario
                imagemUsuario.IdUsuario = idUsuario;
            }

            //verificação caso o usuario ja tenha foto de perfil
            ImagemUsuario imagemExistente = new ImagemUsuario();

            ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == idUsuario);
            if (imagemExistente != null)
            {
                //atualiza pelo objeto (foto) enviado
                imagemExistente.Binario = imagemUsuario.Binario;
                imagemExistente.NomeArquivo = imagemUsuario.NomeArquivo;
                imagemExistente.MimeType = imagemUsuario.MimeType;
                imagemExistente.IdUsuario = idUsuario;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            ctx.ImagemUsuarios.Add(imagemUsuario);
            //salva modificações
            ctx.SaveChanges();
        }
    }
}
