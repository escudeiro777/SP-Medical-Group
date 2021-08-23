CREATE DATABASE MEDICALGROUP_SP
GO

USE MEDICALGROUP_SP;
GO

SELECT * FROM tipoUsuario;
GO

SELECT * FROM usuario;
GO

SELECT * FROM especializacao;
GO

SELECT * FROM clinica;
GO

SELECT * FROM paciente;
GO

SELECT * FROM medico;
GO

SELECT * FROM situacaoConsulta;
GO

SELECT * FROM consulta;
GO

SELECT U.nomeUsuario AS Paciente, UMED.nomeUsuario AS Medico, E.nomeEspecializacao AS Especialização, CONVERT(varchar, C.dataConsulta, 103) AS Data,descricao AS Situação FROM consulta C
INNER JOIN paciente P
ON C.idPaciente = P.idPaciente
INNER JOIN medico M
ON C.idMedico = M.idMedico
INNER JOIN usuario U
ON P.idUsuario = U.idUsuario
INNER JOIN usuario UMED
ON M.idUsuario = UMED.idUsuario
INNER JOIN especializacao E
ON M.idEspecializacao = E.idEspecializacao
INNER JOIN situacaoConsulta S
ON C.idSituacaoConsulta = S.idSituacaoConsulta;
GO

SELECT COUNT(idUsuario) [Quantidade de usuários] FROM usuario;
GO

--Function

CREATE FUNCTION MED_ESPECIALIDADE(@nomeEspec VARCHAR(100))
RETURNS TABLE
AS
RETURN
(
 SELECT @nomeEspec AS Especialização, COUNT(idEspecializacao) [Numero De Médicos] FROM especializacao
 WHERE nomeEspecializacao LIKE '%'+ @nomeEspec +'%'
)
GO

SELECT * FROM MED_ESPECIALIDADE('Pediatria');
GO

--////////////////////////////////////////////////////////////////////////////////////

CREATE PROCEDURE IDADE
@nome VARCHAR(100)
AS
BEGIN
 SELECT U.nomeUsuario, DATEDIFF(YEAR, P.dataNasc, GETDATE()) AS Idade  FROM paciente P
 INNER JOIN usuario U
 ON P.idUsuario = U.idUsuario
 WHERE U.nomeUsuario = @nome
END
GO

exec IDADE 'Mariana'