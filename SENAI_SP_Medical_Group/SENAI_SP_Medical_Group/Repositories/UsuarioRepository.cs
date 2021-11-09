using Microsoft.AspNetCore.Http;
using SENAI_SP_Medical_Group.Contexts;
using SENAI_SP_Medical_Group.Domains;
using SENAI_SP_Medical_Group.Interfaces;
using System;
using System.Collections.Generic;
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
        public Medico BuscarPorId(short id)
        {
           ///
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public string ConsultarPerfilBD(short idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(short id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void SalvarPerfilBD(IFormFile foto, short idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
