using SENAI_SP_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Interfaces
{
    /// <summary>
    /// PacienteRepository Interface
    /// </summary>
    interface IPacienteRepository
    {
        /// <summary>
        /// Cadastrar novo paciente
        /// </summary>
        /// <param name="novoPaciente"> novo paciente cadastrado</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualiza um paciente pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacienteAtualizado"></param>
        void AtualizarUrl(short id, Paciente pacienteAtualizado);

        /// <summary>
        /// Deletar paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente deletado</param>
        void Deletar(short idPaciente);

        /// <summary>
        /// Listar todos os pacientes cadastrados
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um paciente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Paciente Buscado</returns>
        Paciente BuscarPorId(short id);
    }
}
