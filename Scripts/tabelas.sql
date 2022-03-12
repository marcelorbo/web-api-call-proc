/*  Criando Tabela de Situações dos Clientes */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'ClientesSituacoes')
DROP TABLE ClientesSituacoes
GO
CREATE TABLE ClientesSituacoes
(
	Id INT IDENTITY(1,1) NOT NULL,
	Descricao VARCHAR(30) NOT NULL
)
GO
ALTER TABLE ClientesSituacoes ADD CONSTRAINT [PK_ClientesSituacoes] PRIMARY KEY(Id) 
ALTER TABLE ClientesSituacoes ADD CONSTRAINT [UK_ClientesSituacoes] UNIQUE(Descricao)
GO

/* Criando Tabela de Tipos de Clientes */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'ClientesTipos')
DROP TABLE ClientesTipos
GO
CREATE TABLE ClientesTipos
(
	Id INT IDENTITY(1,1) NOT NULL,
	Descricao VARCHAR(30) NOT NULL
)
GO
ALTER TABLE ClientesTipos ADD CONSTRAINT [PK_ClientesTipos] PRIMARY KEY(Id) 
ALTER TABLE ClientesTipos ADD CONSTRAINT [UK_ClientesTiposs] UNIQUE(Descricao)

/* Criando Tabela de Clientes */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'Clientes')
DROP TABLE Clientes
GO
CREATE TABLE Clientes
(
	Id					INT IDENTITY(1,1) NOT NULL,
	Nome				VARCHAR(60) NOT NULL,
	CPF					CHAR(11) NOT NULL,
	Sexo				CHAR(1) NOT NULL,
	IdTipoCliente		INT NOT NULL,
	IdSituacaoCliente	INT NOT NULL
)
GO
ALTER TABLE Clientes ADD CONSTRAINT [PK_Clientes] PRIMARY KEY(Id) 
ALTER TABLE Clientes ADD CONSTRAINT [UK_ClientesCPF] UNIQUE(CPF)
ALTER TABLE Clientes ADD CONSTRAINT [FK_Clientes_ClientesTipos] FOREIGN KEY(IdTipoCliente)
		REFERENCES ClientesTipos(Id)
ALTER TABLE Clientes ADD CONSTRAINT [FK_Clientes_ClientesSituacoes] FOREIGN KEY(IdSituacaoCliente)
		REFERENCES ClientesSituacoes(Id)


/* Populando Tabelas de Dominio */
INSERT INTO ClientesSituacoes ( Descricao ) VALUES ( 'Ativo' )
INSERT INTO ClientesSituacoes ( Descricao ) VALUES ( 'Inativo' )
INSERT INTO ClientesSituacoes ( Descricao ) VALUES ( 'Pendente' )

INSERT INTO ClientesTipos( Descricao ) VALUES ( 'PJ' )
INSERT INTO ClientesTipos( Descricao ) VALUES ( 'PF' )