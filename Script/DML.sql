CREATE DATABASE MEDICALGROUP_SP
GO

USE MEDICALGROUP_SP;
GO

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES ('Administrador'), ('Médico'), ('Paciente')
GO

INSERT INTO usuario(idTipoUsuario,nomeUsuario,email,senha)
VALUES 
(3,'Ligia','ligia@email.com','111'),(3,'Alexandre','alexandre@email.com','222'),
(3,'Fernando','Fernando@email.com','333'),(3,'Henrique','henrique@email.com','444'),
(3,'João','joao@email.com','555'),(3,'Bruno','bruno@email.com','666'),
(3,'Mariana','mariana@email.com','777'),(2,'Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br','888'),(2,'Roberto Possarle','roberto.possarle@spmedicalgroup.com.br','999'),
(2,'Helena Strada','helena.souza@spmedicalgroup.com.br','101010'),(1,'Lucas ADM','ADM@email.com.br','111111')
GO

INSERT INTO situacaoConsulta(situacaoConsulta)
VALUES ('AGENDADA'),('REALIZADA'),('CANCELADA')
GO

INSERT INTO especializacao (nomeEspecializacao)
VALUES 
('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'),
('Cirurgia da Mão'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediátrica'), 
('Cirurgia Plástica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), ('Dermatologia'), ('Radioterapia'), 
('Urologia'), ('Pediatria'), ('Psiquiatria');
GO
 
INSERT INTO clinica (endClinica, nomeFantasia, razaoSocial, cnpj, horaAberto, horaFechado)
VALUES ('Av. Barão Limeira, 532, São Paulo, SP','Clinica Possarle','SP Medical Group','86.400.902/0001-30','07:00','21:00')
GO

INSERT INTO medico(idUsuario,idClinica,idEspecializacao,nomeMedico,crm)
VALUES ('8','1','2','Ricardo Lemos', '45356-SP'),('9','1','17','Roberto Possarle', '54356-SP'),('10','1','16','Helena Strada', '65463-SP')
GO

INSERT INTO paciente (idUsuario,dataNasc,telefone,rg,cpf,endereco)
VALUES
(1, '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'), 
(6, '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'), 
(7, '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'), 
(8, '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'), 
(9, '27/08/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'), 
(10, '21/03/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'), 
(11, '03/05/2018', NULL, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');

INSERT INTO consulta (idPaciente,idMedico,idSituacaoConsulta,dataConsulta,descricao)
VALUES
(7, 7, 2, '01/02/2020 15:00', 'paciente ok'),
(2, 6, 2, '19/06/2021  10:00', NULL), 
(3, 7, 2, '07/02/2021 11:00', 'paciente ok'), 
(2, 6, 2, '24/08/2021 11:00', 'paciente ok'), 
(4, 5, 3, '02/07/2019 11:00', NULL), 
(7, 7, 1, '03/10/2020 21:00', NULL), 
(4, 5, 1, '03/09/2020 11:00', NULL);