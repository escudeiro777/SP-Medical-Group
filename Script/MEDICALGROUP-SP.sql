CREATE DATABASE MEDICALGROUP_SP
GO

USE MEDICALGROUP_SP;
GO

--------------------------------------------------------------ddl--------------------------------------------------------------------

CREATE TABLE tipoUsuario(
 idTipoUsuario TINYINT PRIMARY KEY IDENTITY (1,1),
 nomeTipoUsuario VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario(
 idUsuario INT PRIMARY KEY IDENTITY (1,1), 
 idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
 email VARCHAR(256) NOT NULL UNIQUE,
 senha VARCHAR(25) NOT NULL
);
GO

CREATE TABLE situacaoConsulta(
idSituacaoConsulta TINYINT PRIMARY KEY IDENTITY (1,1),
situacaoConsulta VARCHAR (15)
);
GO


CREATE TABLE especializacao(
 idEspecializacao TINYINT PRIMARY KEY IDENTITY (1,1),
 nomeEspecializacao VARCHAR(100) NOT NULL UNIQUE
);
GO


CREATE TABLE clinica (
 idClinica SMALLINT PRIMARY KEY IDENTITY (1,1),
 endClinica VARCHAR(200) NOT NULL UNIQUE,
 nomeFantasia VARCHAR(200) NOT NULL,
 razaoSocial VARCHAR(200) NOT NULL UNIQUE,
 cnpj VARCHAR(20) NOT NULL UNIQUE,
 horaAberto TIME,
 horaFechado TIME
 );
GO

CREATE TABLE medico (
idMedico SMALLINT PRIMARY KEY IDENTITY (1,1),
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
idClinica SMALLINT FOREIGN KEY REFERENCES Clinica (idClinica),
idEspecializacao TINYINT FOREIGN KEY REFERENCES especializacao (idEspecializacao),
nomeMedico VARCHAR (200) NOT NULL,
crm VARCHAR (20) UNIQUE NOT NULL
);
GO

CREATE TABLE paciente(
 idPaciente INT PRIMARY KEY IDENTITY (1,1),
 idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
 nomePaciente VARCHAR(150) NOT NULL,
 dataNasc DATE NOT NULL,
 telefone VARCHAR(20) UNIQUE,
 rg VARCHAR(15) NOT NULL UNIQUE,
 cpf VARCHAR(15) NOT NULL UNIQUE,
 endereco VARCHAR (256) NOT NULL
);
GO

CREATE TABLE consulta(
idConsulta INT PRIMARY KEY IDENTITY (1,1),
idPaciente INT FOREIGN KEY REFERENCES paciente (idPaciente),
idMedico SMALLINT FOREIGN KEY REFERENCES Medico (idMedico),
idSituacaoConsulta TINYINT FOREIGN KEY REFERENCES situacaoConsulta (idSituacaoConsulta),
dataConsulta DATETIME NOT NULL,
descricao VARCHAR (256)
);
GO

CREATE TABLE imagemUsuario(     
idImagem INT PRIMARY KEY IDENTITY(1,1),     
idUsuario INT NOT NULL UNIQUE FOREIGN KEY REFERENCES usuario(idUsuario),
binario VARBINARY(MAX) NOT NULL,    
mimeType VARCHAR(30) NOT NULL,    
nomeArquivo VARCHAR(250) NOT NULL,     
data_inclusao DATETIME DEFAULT GETDATE() NULL 
); 
GO

drop table consulta
drop table paciente
drop table medico
drop table tipoUsuario
drop table imagemUsuario
drop table clinica
drop table usuario
--------------------------------------------------------------dml--------------------------------------------------------------------
INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES ('Administrador'), ('M�dico'), ('Paciente')
GO

INSERT INTO usuario(idTipoUsuario,email,senha)
VALUES 
(3,'ligia@email.com','111'),(3,'alexandre@email.com','222'),
(3,'Fernando@email.com','333'),(3,'henrique@email.com','444'),
(3,'joao@email.com','555'),(3,'bruno@email.com','666'),
(3,'mariana@email.com','777'),(2,'ricardo.lemos@spmedicalgroup.com.br','888'),(2,'roberto.possarle@spmedicalgroup.com.br','999'),
(2,'helena.souza@spmedicalgroup.com.br','101010'),(1,'ADM@email.com.br','111111')
GO


INSERT INTO situacaoConsulta(situacaoConsulta)
VALUES ('AGENDADA'),('REALIZADA'),('CANCELADA')
GO

INSERT INTO consulta(idPaciente,idMedico,idSituacaoConsulta,dataConsulta,descricao)
VALUES (7,4,1,'20/01/2020  15:00:00','Em observa��o'),
       (2,3,2,'01/06/2020  10:00:00',NULL),(3,2,1,'07/02/2020  11:00:00','Em bom estado '),
	   (2,3,1,'06/02/2018  10:00:00','Em recupera��o'),
	   (4,2,2,'07/02/2019  11:00:45',NULL),
	   (7,4,3,'08/03/2020  15:00:00',NULL),
	   (4,2,3,'09/03/2020  11:00:45',NULL);
GO

INSERT INTO especializacao (nomeEspecializacao)
VALUES 
('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'),
('Cirurgia da M�o'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pedi�trica'), 
('Cirurgia Pl�stica'), ('Cirurgia Tor�cica'), ('Cirurgia Vascular'), ('Dermatologia'), ('Radioterapia'), 
('Urologia'), ('Pediatria'), ('Psiquiatria');
GO
 
INSERT INTO clinica (endClinica, nomeFantasia, razaoSocial, cnpj, horaAberto, horaFechado)
VALUES ('Av. Bar�o Limeira, 532, S�o Paulo, SP','Clinica Possarle','SP Medical Group','86.400.902/0001-30','07:00','21:00')
GO

INSERT INTO medico(idUsuario,idClinica,idEspecializacao,nomeMedico,crm)
VALUES ('8','1','2','Ricardo Lemos', '45356-SP'),('9','1','17','Roberto Possarle', '54356-SP'),('10','1','16','Helena Strada', '65463-SP')
GO

INSERT INTO paciente (idUsuario,nomePaciente,dataNasc,telefone,rg,cpf,endereco)
VALUES
(1,'Ligia', '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, S�o Paulo, Estado de S�o Paulo, 04022-000'), 
(2,'Alexandre', '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200'), 
(3, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200'), 
(4,'Henrique', '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'), 
(5,'Jo�o', '27/08/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380'), 
(6,'Bruno', '21/03/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001'), 
(7, 'Mariana','03/05/2018', NULL, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

INSERT INTO consulta (idPaciente,idMedico,idSituacaoConsulta,dataConsulta,descricao)
VALUES
(7, 1, 2, '01/02/2020 15:00', 'paciente ok'),
(2, 2, 2, '19/06/2021  10:00', NULL), 
(3, 3, 2, '07/02/2021 11:00', 'paciente ok'), 
(2, 3, 2, '24/08/2021 11:00', 'paciente ok'), 
(4, 1, 3, '02/07/2019 11:00', NULL), 
(7, 2, 1, '03/10/2020 21:00', NULL), 
(4, 3, 1, '03/09/2020 11:00', NULL);

----------------------------------------------------------dql-----------------------------------------------------------

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

SELECT U.nomeUsuario AS Paciente, UMED.nomeUsuario AS Medico, E.nomeEspecializacao AS Especializa��o, CONVERT(varchar, C.dataConsulta, 103) AS Data,descricao AS Situa��o FROM consulta C
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

SELECT COUNT(idUsuario) [Quantidade de usu�rios] FROM usuario;
GO

--Function

CREATE FUNCTION MED_ESPECIALIDADE(@nomeEspec VARCHAR(100))
RETURNS TABLE
AS
RETURN
(
 SELECT @nomeEspec AS Especializa��o, COUNT(idEspecializacao) [Numero De M�dicos] FROM especializacao
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