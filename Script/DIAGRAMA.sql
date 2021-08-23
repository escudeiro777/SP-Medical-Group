CREATE DATABASE MEDICALGROUP_SP
GO

USE MEDICALGROUP_SP;
GO

CREATE TABLE tipoUsuario(
 idTipoUsuario TINYINT PRIMARY KEY IDENTITY (1,1),
 nomeTipoUsuario VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario(
 idUsuario INT PRIMARY KEY IDENTITY (1,1), 
 idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
 nomeUsuario VARCHAR(150) NOT NULL,
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
 dataNasc DATE NOT NULL,
 telefone VARCHAR(20) UNIQUE,
 rg VARCHAR(15) NOT NULL UNIQUE,
 cpf VARCHAR(15) NOT NULL UNIQUE,
 endereco VARCHAR (256) NOT NULL
);
GO

DROP TABLE paciente
GO
DROP TABLE consulta
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