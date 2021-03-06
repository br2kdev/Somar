USE SomarDatabase
GO

--select top 10 * from TB_CEP_Bairro
--select top 10 * from TB_CEP_Localidade
--select top 10 * from TB_CEP_Logradouro


select top 10 * from TB_DadosVariaveis
select top 10 * from TB_Generos
select top 10 * from TB_Perfis
select top 10 * from TB_SituacaoPessoas
select top 10 * from TB_TipoPessoas

SELECT A.*, B.siglaGenero, B.descGenero, C.nomeUsuario as nomePessoaUltAlteracao, D.descTipoPessoa
			,descricaoAtivo = CASE WHEN A.flagAtivo = 1 then 'Ativo' else 'Desativado' END
			,descSituacao = CASE WHEN A.idSituacao = 1 then 'Ativo' else 'Desativado' END
FROM TB_Pessoas          A
LEFT JOIN TB_Generos     B ON A.idGenero = B.idGenero
LEFT JOIN TB_Usuarios    C ON A.idPessoaUltAlteracao = C.idUsuario
LEFT JOIN TB_TipoPessoas D ON A.idTipoPessoa = D.idTipoPessoa

/*
truncate table TB_Contatos

truncate table TB_Enderecos
truncate table TB_Escolas
delete TB_Projetos
delete TB_Turmas
truncate table TB_FrequenciaFaltas
delete TB_Frequencia

truncate table TB_Matricula
truncate table TB_PessoaDV
delete  TB_Pessoas

select top 10 * from TB_Pessoas

delete TB_Usuarios where idUsuario in (2,4)
*/

EXEC SPR_GetListaChamada 2006

sp_helptext SPR_GetListaChamada
-- ******************************************************************* --
-- BASE CEP - FONTE http://www.cepaberto.com/
-- ******************************************************************* --
/*
SELECT * FROM TB_Estados
SELECT * FROM TB_Cidades
SELECT * FROM TB_CEPs
*/

-- ******************************************************************* --

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



-- ******************************************************************* --
-- (Projetos Cont�nuos de cada Centro Solid�rio) 
-- Campanhas solid�rias (Festa da P�scoa, Dia das Crian�as e Campanha "Natal � Jesus"). 

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
	idPessoaEducador		INT,
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

exec SPR_GetListaChamada 3

ALTER PROCEDURE SPR_GetListaChamada
(
	@idFrequencia			INT,
	@flagPresenca			INT
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

	CREATE TABLE #TempResult
	(
		idMatricula		INT, 
		idPessoa		INT,
		dtFrequencia	SMALLDATETIME,
		nomePessoa		VARCHAR(100),
		flagPresenca	BIT,
		descPresenca	VARCHAR(100)
	)

	INSERT INTO #TempResult
	SELECT  A.idMatricula, 
			A.idPessoa, 
			dtFrequencia = @dtFrequencia, 
			B.nomePessoa, 
			flagPresenca = (CASE WHEN C.idFrequenciaFalta IS NOT NULL THEN 0 ELSE 1 END),
			descPresenca = null
	FROM TB_Matricula			   A
	INNER JOIN TB_Pessoas		   B ON A.idPessoa     = B.idPessoa
	LEFT  JOIN TB_FrequenciaFaltas C ON C.idFrequencia = @idFrequencia AND A.idPessoa = C.idPessoa
	WHERE  1 = 1 
	  AND  A.idTurma = @idTurma
	  AND  (A.dtCancelamento is NULL OR A.dtCancelamento > @dtFrequencia) 
	  AND  A.dtMatricula < @dtFrequencia

	  if(@flagPresenca = 1)
	  BEGIN
		UPDATE #TempResult SET descPresenca = 'P' WHERE flagPresenca = 1
		UPDATE #TempResult SET descPresenca = 'F' WHERE flagPresenca = 0
	  END

	  SELECT A.idMatricula, 
			 A.idPessoa, 
			 dtFrequencia,
			 A.nomePessoa, 
			 flagPresenca,
			 descPresenca
	  FROM #TempResult A
END

SELECT A.*, b.NomeTurma, c.nomeProjeto, D.nomePessoa
FROM TB_Matricula      A
INNER JOIN TB_Turmas   B ON A.idTurma   = B.idTurma
INNER JOIN TB_Projetos C ON B.idProjeto = C.idProjeto
INNER JOIN TB_Pessoas  D ON A.idPessoa  = D.idPessoa
WHERE A.idTurma = @idTurma

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



-- ******************************************************* 
-- IN�CIO - TABELAS DE DOM�NIO
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
	siglaGenero	VARCHAR(1),
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
-- FINAL - TABELAS DE DOM�NIO
-- ******************************************************* 
--select * from TB_Pessoas
--select * from ##tempCad
/*
select  nomePessoa
		,dtNascimento
		,idTipoPessoa
		,idGenero
		,dtAtivacao
		,numeroRG
		,numeroCPF
		,observacoes
		,idEndereco
		,idContato
		,idEscola
		,fotoBase64
		,0 as flagResponsavel 
		,0 as idSituacao 
		,dtCadastro
		,flagAtivo
		,dtUltAlteracao
		,idPessoaUltAlteracao
into ##tempCad
from TB_Pessoas
 
insert into TB_Pessoas
select * from ##tempCad

*/
--select * from TB_Pessoas

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
	fotoBase64				NVARCHAR(MAX),
	flagResponsavel			BIT,
	idSituacao				INT,
	dtCadastro				SMALLDATETIME,
	flagAtivo				BIT,
	dtUltAlteracao			SMALLDATETIME,
	idPessoaUltAlteracao	INT
)

CREATE TABLE TB_SituacaoPessoas
(
	idSituacao  INT,
	descricao	VARCHAR(50)
)

INSERT INTO TB_SituacaoPessoas values (0, 'N�o informado')
INSERT INTO TB_SituacaoPessoas values (1, 'Verde')
INSERT INTO TB_SituacaoPessoas values (2, 'Amarelo')
INSERT INTO TB_SituacaoPessoas values (3, 'Vermelho')



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
   idPai	 INT,
   idMae	 INT,
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

insert into TB_DadosVariaveis values ('Teste', 1)

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

ALTER TABLE TB_Usuarios ADD FOREIGN KEY (idPessoaUltAlteracao) REFERENCES TB_Usuarios(idUsuario);
ALTER TABLE TB_Turmas ADD FOREIGN KEY (idProjeto) REFERENCES TB_Projetos(idProjeto);

ALTER TABLE TB_Matricula ADD FOREIGN KEY (idTurma) REFERENCES TB_Turmas(idTurma);
ALTER TABLE TB_Matricula ADD FOREIGN KEY (idPessoa) REFERENCES TB_Pessoas(idPessoa);

ALTER TABLE TB_Frequencia ADD FOREIGN KEY (idTurma) REFERENCES TB_Turmas(idTurma);
ALTER TABLE TB_Frequencia ADD FOREIGN KEY (idPessoaUltAlteracao) REFERENCES TB_Usuarios(idUsuario);

ALTER TABLE TB_FrequenciaFaltas ADD FOREIGN KEY (idFrequencia) REFERENCES TB_Frequencia(idFrequencia);
ALTER TABLE TB_FrequenciaFaltas ADD FOREIGN KEY (idPessoa) REFERENCES TB_Pessoas(idPessoa);

ALTER TABLE TB_FrequenciaFaltas ADD FOREIGN KEY (idFrequencia) REFERENCES TB_Frequencia(idFrequencia);
ALTER TABLE TB_FrequenciaFaltas ADD FOREIGN KEY (idPessoa) REFERENCES TB_Pessoas(idPessoa);


-- ******************************************************* 
-- IN�CIO - INSERTS
-- ******************************************************* 
INSERT INTO TB_Perfis   VALUES ('Administrador', 1)

INSERT INTO TB_Generos VALUES ('F','Feminino', 1)
INSERT INTO TB_Generos VALUES ('M','Masculino', 1)

INSERT INTO TB_TipoPessoas VALUES ('Benefici�rio', 1)
INSERT INTO TB_TipoPessoas VALUES ('Educador', 1)
INSERT INTO TB_TipoPessoas VALUES ('Funcion�rio', 1)
INSERT INTO TB_TipoPessoas VALUES ('Professor', 1)
INSERT INTO TB_TipoPessoas VALUES ('Volunt�rio', 1)

INSERT INTO TB_Usuarios VALUES ('Felipe F. Brichucka','Br2k', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Vinicius Vist','Vist', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Hurbem Pinto','Hurbem', '', 1, getdate(), 1, getdate(), 1)
INSERT INTO TB_Usuarios VALUES ('Leonardo Sotto','Sotto', '', 1, getdate(), 1, getdate(), 1)

INSERT INTO TB_DadosVariaveis VALUES ('Batizado', 1)
INSERT INTO TB_DadosVariaveis VALUES ('Eucaristia', 1)
INSERT INTO TB_DadosVariaveis VALUES ('Crisma', 1)

INSERT INTO TB_Pessoas  VALUES ('FELIPE FURTADO BRICHUCKA', '09/19/1986', 5, 2, getdate(), '41.387.404-7', '229.260.568-69', 'OBS.TESTE', NULL, NULL, 0, GETDATE(), 1, GETDATE(), 0)

-- ****************************** -- 
-- ALUNOS POR ESCOLA
-- ****************************** -- 
SELECT id = A.idEscola, displayName = A.nomeEscola, displayCount = COUNT(1)
FROM TB_Escolas		  A
INNER JOIN TB_Pessoas B ON A.idEscola = B.idEscola
GROUP BY A.idEscola, A.nomeEscola

-- ****************************** -- 
-- ALUNOS POR PROJETO (Matricula)
-- ****************************** -- 
SELECT C.idProjeto, C.nomeProjeto, QtdeAlunos = COUNT(1)
FROM TB_Matricula      A
INNER JOIN TB_Turmas   B ON A.idTurma   = B.idTurma
INNER JOIN TB_Projetos C ON B.idProjeto = C.idProjeto
WHERE A.dtCancelamento IS NOT NULL
GROUP BY C.idProjeto, C.nomeProjeto


SELECT b.NomeProjeto, A.* 
FROM TB_Turmas A
inner join TB_Projetos B ON A.idProjeto = B.idProjeto
--inner join TB_Pessoas  C ON A.idPessoaPae = C.idPessoa

select * from TB_DadosVariaveis 

delete TB_DadosVariaveis wh	ere idDadoVariavel in (4, 5, 6)

-- ****************************** -- 
-- ALUNOS POR EDUCADOR
-- ****************************** -- 
SELECT B.idPessoaEducador, C.nomePessoa, QtdeAlunos = COUNT(1)
FROM TB_Matricula      A
INNER JOIN TB_Turmas   B ON A.idTurma   = B.idTurma
INNER JOIN TB_Pessoas  C ON B.idPessoaEducador   = C.idPessoa
WHERE A.dtCancelamento IS NOT NULL
GROUP BY B.idPessoaEducador, C.nomePessoa


-- ****************************** -- 
-- PESSOAS POR BAIRRO
-- ****************************** -- 
SELECT B.idBairro, C.bai_no, QtdePessoas = COUNT(1)
FROM  TB_Pessoas		  A
INNER JOIN TB_Enderecos   B ON A.idEndereco = B.idEndereco
INNER JOIN TB_CEP_Bairro  C ON B.idBairro   = C.bai_nu_sequencial
GROUP BY B.idBairro, C.bai_no

-- ****************************** -- 
-- ALUNOS POR FAIXA ETARIA
-- ****************************** -- 

SELECT 
		SUM(CASE WHEN A.idade BETWEEN 0 and 2 then 1 ELSE 0 END)  as ZeroADois,
		SUM(CASE WHEN A.idade BETWEEN 3 and 4 then 1 ELSE 0 END)  as TresAQuatro,
		SUM(CASE WHEN A.idade BETWEEN 5 and 6 then 1 ELSE 0 END)  as CincoASeis,
		SUM(CASE WHEN A.idade BETWEEN 5 and 6 then 1 ELSE 0 END)  as CincoASeis,
		SUM(CASE WHEN A.idade BETWEEN 7 and 50 then 1 ELSE 0 END) as MaisD7
FROM (
		SELECT dbo.calcular_idade(dtNascimento, GETDATE()) AS idade -- QtdePessoas = COUNT(1)
		FROM  TB_Pessoas		  A
		INNER JOIN TB_Matricula   B ON A.idPessoa = B.idPessoa
		WHERE B.dtCancelamento IS NOT NULL
	 ) A

--select * from TB_Pessoas
--GROUP BY idade



-- ****************************** -- 
-- ALUNOS POR Educador
-- ****************************** --

 

CREATE FUNCTION calcular_idade(@nascimento DATE, @data_base DATE)
RETURNS INT
AS
BEGIN
  DECLARE @idade      INT;
  DECLARE @dia_inicio INT;
  DECLARE @dia_fim    INT;

  SET @data_base = ISNULL(@data_base, GETDATE()); -- Caso seja nula considera a data atual
  SET @idade = DATEDIFF(YEAR, @nascimento, @data_base);
  -- Deve ser feito dessa forma por conta do ano bissexto
  -- Por exemplo: dia 16/06 ficar� 616 e 14/12 ficar� 1214
  SET @dia_inicio = (MONTH(@nascimento) * 100) + DAY(@nascimento);
  SET @dia_fim = (MONTH(@data_base) * 100) + DAY(@data_base);

  -- Se ainda n�o passou no ano base
  IF @dia_fim < @dia_inicio
  BEGIN
    SET @idade = @idade - 1;
  END;

  RETURN @idade;
END;
GO


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

CREATE CLUSTERED INDEX IX#01_TB_SituacaoPessoas ON TB_SituacaoPessoas(idSituacao)

-- ************************************************************************* --
-- CEP INDEXES
-- ************************************************************************* --

CREATE CLUSTERED INDEX IX#01_Logradouro ON TB_CEP_Logradouro (CEP ASC)
CREATE CLUSTERED INDEX IX#01_Localidade ON TB_CEP_Localidade(loc_nu_sequencial)
CREATE CLUSTERED INDEX IX#01_Bairro		ON TB_CEP_Bairro(bai_nu_sequencial)

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


select * from TB_Usuarios