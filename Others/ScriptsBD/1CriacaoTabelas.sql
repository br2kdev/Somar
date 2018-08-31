USE SomarDatabase
GO

-- ******************************************************************* --
-- BASE CEP - FONTE http://www.cepaberto.com/
-- ******************************************************************* --
/*
SELECT * FROM TB_Estados
SELECT * FROM TB_Cidades
SELECT * FROM TB_CEPs
*/
-- ******************************************************************* --

CREATE TABLE TB_Projetos
(
	idProjeto				INT IDENTITY(1,1),
	nomeProjeto				NVARCHAR(100),
	descricaoProjeto		NVARCHAR(400),
	dataInicio				SMALLDATETIME,
	dataTermino				SMALLDATETIME,
	idPessoaResposavel		INT, 
	dataCadastro			SMALLDATETIME,
	flagAtivo				BIT,
	dataUltAlteracao		SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

CREATE TABLE TB_Turmas
(
	idTurma					INT IDENTITY(1,1),
	nomeTurma				NVARCHAR(100),
	descricaoTurma			NVARCHAR(400),
	descricaoPeriodo		VARCHAR(20),
	HoraInicio				VARCHAR(10),
	HoraTermino				VARCHAR(10),
	idPessoaEducador		INT,
	dataCadastro			SMALLDATETIME,
	flagAtivo				BIT,
	dataUltAlteracao		SMALLDATETIME,
	idPessoaUltAlteracao	INT,
	idProjeto				INT
)

CREATE TABLE TB_Usuarios
(
	idUsuario				INT IDENTITY(1,1),
	nomeUsuario				NVARCHAR(100),
	login					NVARCHAR(30),
	senha					NVARCHAR(15),
	idPerfil				INT,
	dataCadastro			SMALLDATETIME,
	flagAtivo				BIT,
	dataUltAlteracao		SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

-- ******************************************************* 
-- INÍCIO - TABELAS DE DOMÍNIO
-- ******************************************************* 
CREATE TABLE TB_Perfis 
(
   idPerfil		INT IDENTITY(1,1),
   descPerfil	VARCHAR(50),
   flagAtivo	BIT,
)

CREATE TABLE TB_Generos
(
	idGenero	INT IDENTITY(1,1),
	descGenero	VARCHAR(100),
	flagAtivo	BIT,
)

CREATE TABLE TB_TipoPessoas
(
	idTipoPessoa	INT IDENTITY(1,1),
	descTipoPessoa	VARCHAR(100),
	flagAtivo		BIT,
)


-- ******************************************************* 
-- FINAL - TABELAS DE DOMÍNIO
-- ******************************************************* 

CREATE TABLE TB_Pessoas
(
	idPessoa				INT IDENTITY(1,1),
	nomePessoa				NVARCHAR(100),
	dataNascimento			SMALLDATETIME,
	idTipoPessoa			INT,	
	idGenero				INT,		
	dataAtivacao			SMALLDATETIME,
	numeroRG				VARCHAR(20),
	numeroCPF				VARCHAR(20),
	observacoes				VARCHAR(400),
	idEndereco				INT,
	idContato				INT,
	dataCadastro			SMALLDATETIME,
	flagAtivo				BIT,
	dataUltAlteracao		SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

CREATE TABLE TB_Enderecos
(
	idEndereco				INT IDENTITY(1,1),
	CEP						VARCHAR(10),
	logradouro				NVARCHAR(100),
	complemento				NVARCHAR(100),
	numero					NVARCHAR(100),
	idBairro				INT,		
	nomeBairro				NVARCHAR(100),
	idCidade				INT,
	nomeCidade				NVARCHAR(100),
	siglaUF					VARCHAR(2),
	idPessoa				INT
)

CREATE TABLE TB_Contatos
(
   idContato INT IDENTITY(1,1),
   nomePai	 VARCHAR(100),
   nomeMae	 VARCHAR(100),
   telefone1 VARCHAR(100),
   contato1	 VARCHAR(100),
   telefone2 VARCHAR(100),
   contato2	 VARCHAR(100),
   telefone3 VARCHAR(100),
   contato3	 VARCHAR(100)
)

CREATE TABLE TB_DadosVariaveis
(
	idDadoVariavel		INT IDENTITY(1,1),
	nomeDadoVariavel	VARCHAR(100),
	flagAtivo			BIT
)

CREATE TABLE TB_PessoaDV
(
	identificador	INT IDENTITY(1,1)
	idPessoa		INT,
	idDadoVariavel	INT,
	flagMarcador	BIT
)

select * from TB_Usuarios
select * from TB_Perfis
select * from TB_Pessoas


-- ******************************************************* 
-- INÍCIO - INSERTS
-- ******************************************************* 
INSERT INTO TB_Usuarios VALUES ('Felipe F. Brichucka','admin', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Perfis   VALUES ('Administrador', 1)

INSERT INTO TB_Generos VALUES ('Feminino', 1)
INSERT INTO TB_Generos VALUES ('Masculino', 1)

INSERT INTO TB_TipoPessoas VALUES ('Beneficiário', 1)
INSERT INTO TB_TipoPessoas VALUES ('Educador', 1)
INSERT INTO TB_TipoPessoas VALUES ('Funcionário', 1)
INSERT INTO TB_TipoPessoas VALUES ('Professor', 1)
INSERT INTO TB_TipoPessoas VALUES ('Voluntário', 1)

INSERT INTO TB_Pessoas  VALUES ('FELIPE FURTADO BRICHUCKA', '09/19/1986', 5, 2, getdate(), '41.387.404-7', '229.260.568-69', 'OBS.TESTE', NULL, NULL, GETDATE(), 1, GETDATE(), 0)


/*
USE CorreiroDatabase2014
GO

SELECT TOP 50 * FROM CorreiroDatabase2014..log_logradouro

SELECT 
  A.LOG_NOME	AS Logradouro,
  C.bai_no		AS Bairro,
  B.loc_no		AS Cidade,
  B.ufe_sg		AS UF,
  A.cep
FROM  TB_CEP_Logradouro      A
INNER JOIN TB_CEP_Localidade B ON A.loc_nu_sequencial = B.loc_nu_sequencial
INNER JOIN TB_CEP_Bairro     C ON A.bai_nu_sequencial_ini = C.bai_nu_sequencial
WHERE A.cep = '07195120'

CREATE INDEX IX#01_LOGRADOURO ON TB_CEP_Logradouro(CEP)
CREATE INDEX IX#02_LOGRADOURO ON TB_CEP_Logradouro(loc_nu_sequencial)
CREATE INDEX IX#01_Localidade ON TB_CEP_Localidade(loc_nu_sequencial)
CREATE INDEX IX#01_Bairro ON TB_CEP_Bairro(bai_nu_sequencial)

SELECT 
	Log_logradouro.LOG_NOME	AS LOGRADOURO, 
	Log_logradouro.CEP, 
	Log_logradouro.LOC_NU_SEQUENCIAL, 
	Log_logradouro.UFE_SG, 
	Log_Logradouro.LOG_NU_SEQUENCIAL,
    Log_Logradouro.LOG_STATUS_TIPO_LOG, 
	Log_bairro.BAI_NO AS INICIAL, 
	Log_Localidade.LOC_NO,
        ( SELECT BAI_NO FROM LOG_BAIRRO WHERE BAI_NU_SEQUENCIAL = Log_Logradouro.BAI_NU_SEQUENCIAL_FIM) AS FINAL
FROM 
	LOG_LOGRADOURO Log_logradouro,   
	LOG_BAIRRO Log_bairro, 
	LOG_LOCALIDADE Log_Localidade
WHERE 
	(Log_logradouro.UFE_SG = Log_bairro.UFE_SG)
	AND (Log_logradouro.LOC_NU_SEQUENCIAL = Log_bairro.LOC_NU_SEQUENCIAL)
	AND (Log_logradouro.BAI_NU_SEQUENCIAL_INI = Log_bairro.BAI_NU_SEQUENCIAL)
	AND (Log_logradouro.UFE_SG = Log_localidade.UFE_SG)
	AND (Log_logradouro.LOC_NU_SEQUENCIAL = Log_localidade.LOC_NU_SEQUENCIAL)
	AND (Log_logradouro.CEP = '06727220')
ORDER BY  
	Log_logradouro.LOG_TIPO_LOGRADOURO, Log_logradouro.LOG_NO

	select * from TB_Enderecos
	TB_Pessoas

*/

SELECT *,  descricaoAtivo = CASE WHEN flagAtivo = 1 then 'Ativo' else 'Desativado' END FROM TB_Pessoas A LEFT JOIN TB_Genero    B ON A.idGenero = B.idGenero WHERE 1 = 1  AND idPessoa = 2

--truncate table TB_Enderecos
select * from TB_Pessoas
select * from TB_Enderecos

alter table TB_Enderecos add siglaUF varchar(2)

--EXEC USP_Projeto

/*
TRUNCATE TABLE TB_Projetos
select * from TB_Projetos
insert into TB_Projetos values ('PROJETO 1', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 2', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 3', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 4', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 5', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 6', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 7', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
insert into TB_Projetos values ('PROJETO 8', 'DESCRICAO DO PROJETO', GETDATE(), GETDATE(), 1, GETDATE(), 1, GETDATE(), 1)
*/