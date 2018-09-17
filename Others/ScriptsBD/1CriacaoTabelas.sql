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
-- (Projetos Contínuos de cada Centro Solidário) 
-- Campanhas solidárias (Festa da Páscoa, Dia das Crianças e Campanha "Natal é Jesus"). 

SELECT  idProjeto
		nomeProjeto
		descricaoProjeto
		dtInicio
		dtTermino
		nomeResposavel
		dtCadastro
		flagAtivo
		dtUltAlteracao
		idPessoaUltAlteracao
FROM dbo.TB_Projetos

CREATE TABLE TB_Projetos
(
	idProjeto				INT IDENTITY(1,1) PRIMARY KEY,
	nomeProjeto				NVARCHAR(100),
	descricaoProjeto		NVARCHAR(400),
	dtInicio				SMALLDATETIME,
	dtTermino				SMALLDATETIME,
	nomeResposavel			VARCHAR(100),
	-- idPessoaResposavel	INT,				-- Alterar para nome
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

-- ALTER TABLE TB_Projetos ALTER COLUMN idPessoaResposavel VARCHAR(100)

CREATE TABLE TB_Turmas
(
	idTurma					INT IDENTITY(1,1) PRIMARY KEY,
	nomeTurma				NVARCHAR(100),
	descricaoTurma			NVARCHAR(400),
	descricaoPeriodo		VARCHAR(20),
	HoraInicio				VARCHAR(10),
	HoraTermino				VARCHAR(10),
	--idPessoaEducador		INT,
	nomeEducador			VARCHAR(100),
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT,
	idProjeto				INT
)

CREATE TABLE TB_Matricula
(
	idMatricula				INT IDENTITY(1,1) PRIMARY KEY,
	idPessoa				INT,
	idTurma					INT,
	dtMatricula				SMALLDATETIME,
	dtCancelamento			SMALLDATETIME,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

-- select * from TB_Frequencia
-- select * from TB_FrequenciaAluno

CREATE TABLE TB_Frequencia
(
	idFrequencia			INT IDENTITY(1,1) PRIMARY KEY,
	dtFrequencia			SMALLDATETIME,
	idTurma					INT,
	idDisciplina			INT,
	dtCadastro				SMALLDATETIME,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

CREATE TABLE TB_FrequenciaFaltas
(
	idFrequenciaFalta		INT IDENTITY(1,1) PRIMARY KEY,
	idFrequencia			INT,
	idPessoa				INT,
	justificativa			VARCHAR(100)
)

SELECT iCount = (SELECT COUNT(1) 
				 FROM TB_Matricula B 
				 WHERE B.idPessoa = A.idPessoa
				 AND dtCancelamento is null), *
FROM TB_Pessoas	A

-- select * from TB_Matricula
-- select * from TB_Frequencia
-- select * from TB_FrequenciaAluno
-- DROP PROCEDURE SPR_GerarFrequencia
-- EXEC SPR_GerarFrequencia 6
-- SELECT * FROM TB_Frequencia		WHERE idTurma = 1
-- SELECT * FROM TB_FrequenciaAluno WHERE idTurma = 1


CREATE PROCEDURE SPR_AtualizaListaChamada
(
	@idFrequencia	INT,
	@idPessoa		INT,
	@flagPresenca	BIT
)
AS
BEGIN
	
	IF(@flagPresenca = 1)
	BEGIN
		DELETE TB_FrequenciaFaltas WHERE idFrequencia = @idFrequencia AND idPessoa = @idPessoa
	END
	ELSE
	BEGIN
		INSERT INTO TB_FrequenciaFaltas (idFrequencia, idPessoa) VALUES (@idFrequencia, @idPessoa)
	END
 
END

CREATE PROCEDURE SPR_GetListaChamada
(
	@idFrequencia			INT
)
AS
BEGIN

	DECLARE @idTurma		INT
	DECLARE @dtFrequencia	SMALLDATETIME
		
	--SELECT * FROM TB_Frequencia
	--SELECT * FROM TB_Matricula where idTurma = 1

	SELECT TOP 1 @idTurma = idTurma, @dtFrequencia = dtFrequencia 
	FROM TB_Frequencia 
	WHERE idFrequencia = @idFrequencia

	-- SELECT * FROM TB_FrequenciaAluno
	-- INSERT INTO TB_FrequenciaAluno (idFrequencia, idPessoa, flagPresenca)
	/*
	SELECT @idFrequencia, idPessoa, 1
	FROM TB_Matricula 
	WHERE 1 = 1 
	AND  idTurma = @idTurma
	AND  dtCancelamento is NULL
	AND  dtMatricula < @dtFrequencia
	*/

	SELECT A.idMatricula, A.idPessoa, dtFrequencia = @dtFrequencia, B.nomePessoa, flagPresenca = (CASE WHEN C.idFrequenciaFalta IS NOT NULL THEN 0 ELSE 1 END)
	FROM TB_Matricula			   A
	INNER JOIN TB_Pessoas		   B ON A.idPessoa     = B.idPessoa
	LEFT  JOIN TB_FrequenciaFaltas C ON C.idFrequencia = @idFrequencia AND A.idPessoa = C.idPessoa
	WHERE  1 = 1 
	  AND  A.idTurma = @idTurma
	  AND  (A.dtCancelamento is NULL OR A.dtCancelamento > @dtFrequencia) 
	  AND  A.dtMatricula < @dtFrequencia
	  
END

ALTER PROCEDURE SPR_GerarFrequencia
(
	@idFrequencia			INT
	
)
AS
BEGIN
	
	SELECT * FROM TB_Frequencia
	SELECT * FROM TB_Matricula where idTurma = 1

	DECLARE @idTurma		INT
	DECLARE @dtFrequencia	SMALLDATETIME
	
	SELECT TOP 1 @idTurma = idTurma, @dtFrequencia = dtFrequencia 
	FROM TB_Frequencia 
	WHERE idFrequencia = @idFrequencia

	-- SELECT * FROM TB_FrequenciaAluno
	INSERT INTO TB_FrequenciaFaltas (idFrequencia, idPessoa, flagPresenca)
	SELECT @idFrequencia, idPessoa, 1
	FROM TB_Matricula 
	WHERE 1 = 1 
	AND  idTurma = @idTurma
	AND  dtCancelamento is NULL
	AND  dtMatricula < @dtFrequencia
END

CREATE TABLE TB_Usuarios
(
	idUsuario				INT IDENTITY(1,1) PRIMARY KEY,
	nomeUsuario				NVARCHAR(100),
	login					NVARCHAR(30),
	senha					NVARCHAR(15),
	idPerfil				INT,
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

-- ******************************************************* 
-- INÍCIO - TABELAS DE DOMÍNIO
-- ******************************************************* 
CREATE TABLE TB_Perfis 
(
   idPerfil		INT IDENTITY(1,1) PRIMARY KEY,
   descPerfil	VARCHAR(50),
   flagAtivo	BIT,
)

CREATE TABLE TB_Generos
(
	idGenero	INT IDENTITY(1,1) PRIMARY KEY,
	descGenero	VARCHAR(100),
	flagAtivo	BIT,
)

CREATE TABLE TB_TipoPessoas
(
	idTipoPessoa	INT IDENTITY(1,1) PRIMARY KEY,
	descTipoPessoa	VARCHAR(100),
	flagAtivo		BIT,
)

-- ******************************************************* 
-- FINAL - TABELAS DE DOMÍNIO
-- ******************************************************* 
--select * from TB_Pessoas
alter table TB_Pessoas alter column arrayFoto NVARCHAR(4000)

CREATE TABLE TB_Pessoas
(
	idPessoa				INT IDENTITY(1,1) PRIMARY KEY,
	nomePessoa				NVARCHAR(100),
	dtNascimento			SMALLDATETIME,
	idTipoPessoa			INT,	
	idGenero				INT,		
	dtAtivacao				SMALLDATETIME,
	numeroRG				VARCHAR(20),
	numeroCPF				VARCHAR(20),
	observacoes				VARCHAR(400),	
	idEndereco				INT,
	idContato				INT,
	idEscola				INT,
	arrayFoto				NVARCHAR(MAX),
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

CREATE TABLE TB_Enderecos
(
	idEndereco				INT IDENTITY(1,1) PRIMARY KEY,
	CEP						VARCHAR(10),
	logradouro				NVARCHAR(100),
	complemento				NVARCHAR(100),
	numero					NVARCHAR(100),
	idBairro				INT,		
	nomeBairro				NVARCHAR(100),
	idCidade				INT,
	nomeCidade				NVARCHAR(100),
	siglaUF					VARCHAR(2)
)

CREATE TABLE TB_Contatos
(
   idContato INT IDENTITY(1,1) PRIMARY KEY,
   nomePai	 VARCHAR(100),
   nomeMae	 VARCHAR(100),
   telefone1 VARCHAR(100),
   contato1	 VARCHAR(100),
   telefone2 VARCHAR(100),
   contato2	 VARCHAR(100),
   telefone3 VARCHAR(100),
   contato3	 VARCHAR(100)
)

-- ****************************************************************

CREATE TABLE TB_DadosVariaveis
(
	idDadoVariavel		INT IDENTITY(1,1) PRIMARY KEY,
	nomeDadoVariavel	VARCHAR(100),
	flagAtivo			BIT
)

CREATE TABLE TB_PessoaDV
(
	identificador	INT IDENTITY(1,1) PRIMARY KEY,
	idPessoa		INT,
	idDadoVariavel	INT,
	flagMarcador	BIT
)

--truncate table TB_Escolas
--drop table TB_Escolas
CREATE TABLE TB_Escolas
(
	idEscola				INT IDENTITY(1,1) PRIMARY KEY,
	nomeEscola				VARCHAR(100),
	observacoes				varchar(400),
	idEndereco				INT,
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

select * from TB_Usuarios
select * from TB_Perfis
select * from TB_Pessoas
select * from TB_Pessoas

SELECT * 
FROM TB_Pessoas A
WHERE  month(dtNascimento) = month(getdate())

/*
drop table TB_Projetos
drop table TB_Turmas
drop table TB_Matricula
drop table TB_Frequencia
drop table TB_FrequenciaFaltas
drop table TB_Usuarios
drop table TB_Perfis
drop table TB_Generos
drop table TB_TipoPessoas
drop table TB_Pessoas
drop table TB_Enderecos
drop table TB_Contatos
*/

-- ******************************************************* 
-- INÍCIO - INSERTS
-- ******************************************************* 
INSERT INTO TB_Perfis   VALUES ('Administrador', 1)

INSERT INTO TB_Generos VALUES ('Feminino', 1)
INSERT INTO TB_Generos VALUES ('Masculino', 1)

INSERT INTO TB_TipoPessoas VALUES ('Beneficiário', 1)
INSERT INTO TB_TipoPessoas VALUES ('Educador', 1)
INSERT INTO TB_TipoPessoas VALUES ('Funcionário', 1)
INSERT INTO TB_TipoPessoas VALUES ('Professor', 1)
INSERT INTO TB_TipoPessoas VALUES ('Voluntário', 1)

INSERT INTO TB_Usuarios VALUES ('Felipe F. Brichucka','Br2k', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Vinicius Vist','Vist', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Hurbem Pinto','Hurbem', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Leonardo Sotto','Sotto', '', 1, getdate(), 1, getdate(), 1)

INSERT INTO TB_Pessoas  VALUES ('FELIPE FURTADO BRICHUCKA', '09/19/1986', 5, 2, getdate(), '41.387.404-7', '229.260.568-69', 'OBS.TESTE', NULL, NULL, 0, GETDATE(), 1, GETDATE(), 0)

INSERT INTO TB_DadosVariaveis VALUES ('Batizado', 1)
INSERT INTO TB_DadosVariaveis VALUES ('Eucaristia', 1)
INSERT INTO TB_DadosVariaveis VALUES ('Crisma', 1)

-- ************************************************************************* --
-- INDEXES
-- ************************************************************************* --
CREATE CLUSTERED INDEX IX#01_TB_Projetos ON TB_Projetos(idProjeto)
CREATE CLUSTERED INDEX IX#01_TB_Turmas   ON TB_Turmas(idTurma)
CREATE INDEX IX#02_TB_Turmas   ON TB_Turmas(idProjeto)

CREATE CLUSTERED INDEX IX#01_TB_Matricula ON TB_Matricula(idMatricula)
CREATE INDEX IX#02_TB_Matricula ON TB_Matricula(idPessoa)
CREATE INDEX IX#03_TB_Matricula ON TB_Matricula(idTurma)

CREATE CLUSTERED INDEX IX#01_TB_Frequencia ON TB_Frequencia(idFrequencia)
CREATE INDEX IX#02_TB_Frequencia ON TB_Frequencia(idTurma)

CREATE CLUSTERED INDEX IX#01_TB_FrequenciaFaltas ON TB_FrequenciaFaltas(idFrequenciaFalta)
CREATE INDEX IX#02_TB_FrequenciaFaltas ON TB_FrequenciaFaltas(idFrequencia)
CREATE INDEX IX#03_TB_FrequenciaFaltas ON TB_FrequenciaFaltas(idPessoa)

CREATE CLUSTERED INDEX IX#01_TB_Usuarios ON TB_Usuarios(idUsuario)
CREATE INDEX IX#02_TB_Usuarios ON TB_Usuarios(login)

CREATE CLUSTERED CLUSTERED INDEX IX#01_TB_Perfis      ON TB_Perfis(idPerfil)
CREATE CLUSTERED INDEX IX#01_TB_Generos     ON TB_Generos(idGenero)
CREATE CLUSTERED INDEX IX#01_TB_TipoPessoas ON TB_TipoPessoas(idTipoPessoa)

CREATE CLUSTERED INDEX IX#01_TB_Pessoas   ON TB_Pessoas(idPessoa)
CREATE CLUSTERED INDEX IX#01_TB_Enderecos ON TB_Enderecos(idEndereco)
CREATE CLUSTERED INDEX IX#01_TB_Contatos  ON TB_Contatos(idContato)

-- ************************************************************************* --
-- CEP INDEXES
-- ************************************************************************* --

CREATE CLUSTERED INDEX IX#01_Logradouro ON TB_CEP_Logradouro (CEP ASC)
CREATE CLUSTERED INDEX IX#01_Localidade ON TB_CEP_Localidade(loc_nu_sequencial)
CREATE CLUSTERED INDEX IX#01_Bairro		ON TB_CEP_Bairro(bai_nu_sequencial)

TB_Enderecos

@CEP,
@logradouro,
@complemento,
@numero,
@idBairro,
@nomeBairro,
@idCidade,
@nomeCidade,
@siglaUF

CEP
logradouro
complemento
numero
idBairro
nomeBairro
idCidade
nomeCidade
siglaUF

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