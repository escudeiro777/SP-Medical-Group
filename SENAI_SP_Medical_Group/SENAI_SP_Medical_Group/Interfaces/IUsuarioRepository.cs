using Microsoft.AspNetCore.Http;
using SENAI_SP_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Interfaces
{
    /// <summary>
    /// UsuarioRepository Interface
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Login de usuário
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>token de login</returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Cadastrar novo usuario
        /// </summary>
        /// <param name="novoUsuario"> novo usuario cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deletar usuario
        /// </summary>
        /// <param name="id">ID do usuario deletado</param>
        void Deletar(short id);

        /// <summary>
        /// Listar todos os usuarios cadastrados
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um usuario pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Buscado</returns>
        Usuario BuscarPorId(short id);

        /// <summary>
        /// Salvar imagem de perfil no banco
        /// </summary>
        /// <param name="foto">Imagem salva</param>
        /// <param name="idUsuario">ID do usuario que a terá a imagem salva</param>
        void SalvarPerfilBD(IFormFile foto, short idUsuario);

        /// <summary>
        /// Consulta imagem pelo BD
        /// </summary>
        /// <param name="idUsuario">ID do usuario que será consultado</param>
        /// <returns>Perfil do usuario</returns>
        string ConsultarPerfilBD(short idUsuario);
    }
}