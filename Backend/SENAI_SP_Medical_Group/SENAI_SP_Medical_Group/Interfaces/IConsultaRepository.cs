using SENAI_SP_Medical_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.Interfaces
{
    /// <summary>
    /// ConsultaRepository Interface
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Cadastrar nova consulta
        /// </summary>
        /// <param name="novaConsulta">nova consulta cadastrada</param>
        void Cadastrar(Consultum novaConsulta);

        /// <summary>
        /// Atualiza uma consulta pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consultaAtualizada"></param>
        void AtualizarUrl(int id, Consultum consultaAtualizada);

        /// <summary>
        /// Deletar consulta
        /// </summary>
        /// <param name="id">ID da consulta deletada</param>
        void Deletar(short id);

        /// <summary>
        /// Lista as consultas de um médico ou um paciente em especifico
        /// </summary>
        /// <param name="id">ID ou do médico ou do paciente</param>
        /// <param name="idTipo">ID do tipo de usuario</param>
        /// <returns>Uma lista de consultas especificas</returns>
        List<Consultum> ListarMinhas(short id, short idTipo);

        /// <summary>
        /// Muda a descricao de uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que mudará a descricao</param>
        /// <param name="descricao">Nova descricao</param>
        void mudarDescricao(short id, string descricao);

        /// <summary>
        /// Muda a situacao de uma consulta
        /// </summary>
        /// <param name="idConsulta">ID da consulta que terá a situação atualizada</param>
        /// <param name="idSituacao">ID que sera atualizado</param>
        void mudarSituacao(short idConsulta, short idSituacao);

        /// <summary>
        /// Busca uma consulta pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Consulta Buscada</returns>
        Consultum BuscarPorId(short id);

        List<Consultum> ListarTodas();
    }
}
