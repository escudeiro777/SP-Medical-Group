using SENAI_SP_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Interfaces
{
    /// <summary>
    /// ClinicaRepository Interface
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Cadastrar nova clínica
        /// </summary>
        /// <param name="novaClinica"> nova clínica cadastrada</param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma clinica pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinicaAtualizada"></param>
        void AtualizarUrl(short id, Clinica clinicaAtualizada);

        /// <summary>
        /// Deletar clínica
        /// </summary>
        /// <param name="id">ID da clínica deletado</param>
        void Deletar(short id);

        /// <summary>
        /// Listar todas as clinicas cadastradas
        /// </summary>
        /// <returns>Lista de clinicas</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca uma clinica pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Clinica Buscada</returns>
        Clinica BuscarPorId(short id);
    }
}
