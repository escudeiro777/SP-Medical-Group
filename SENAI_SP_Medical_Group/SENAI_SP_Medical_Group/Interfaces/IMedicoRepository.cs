using SENAI_SP_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Interfaces
{
    /// <summary>
    /// MedicoRepository Interface
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Cadastrar novo médico
        /// </summary>
        /// <param name="novoMedico"> novo médico cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um medico pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicoAtualizado"></param>
        void AtualizarUrl(short id, Medico medicoAtualizado);

        /// <summary>
        /// Deletar medico
        /// </summary>
        /// <param name="id">ID do médico deletado</param>
        void Deletar(short id);

        /// <summary>
        /// Listar todos os medicos cadastrados
        /// </summary>
        /// <returns>Lista de médicos</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Busca um medico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Medico Buscado</returns>
        Medico BuscarPorId(short id);
    }
}
