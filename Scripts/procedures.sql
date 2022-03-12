/* Procedures Para Manipulação das Tabela de Clientes, Tipos de Clientes, Situacoes de Clientes */

/* Listar */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'ListarClientes')
DROP PROCEDURE ListarClientes
GO
CREATE PROCEDURE [dbo].[ListarClientes]
	@CPF CHAR(11) = NULL
AS
BEGIN
	SELECT 
			A.Id, 
			Nome, 
			CPF, 
			Sexo, 
			B.Id IdTipoCliente,
			B.Descricao TipoCliente,
			C.Id IdSituacaoCliente,
			C.Descricao SituacaoCliente
		FROM Clientes A 
		INNER JOIN ClientesTipos B
		ON A.IdTipoCliente = B.Id
		INNER JOIN ClientesSituacoes C
		ON A.IdSituacaoCliente = C.Id
		WHERE CPF = ISNULL(@CPF, CPF)
END
GO

/* Salvar */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'SalvarCliente')
DROP PROCEDURE SalvarCliente
GO
CREATE PROCEDURE [dbo].[SalvarCliente]
	@Nome		VARCHAR(60),
	@CPF		CHAR(11),
	@Sexo		CHAR(1),
	@Tipo		INT,
	@Situacao	INT
AS
BEGIN
	BEGIN TRAN
		INSERT INTO Clientes ( Nome, CPF, Sexo, IdTipoCliente, IdSituacaoCliente )
		VALUES ( @Nome, @CPF, @Sexo, @Tipo, @Situacao )
	COMMIT TRAN
END
GO

/* Atualizar */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'AtualizarCliente')
DROP PROCEDURE AtualizarCliente
GO
CREATE PROCEDURE [dbo].[AtualizarCliente]
	@Id			INT,
	@Nome		VARCHAR(60),
	@CPF		CHAR(11),
	@Sexo		CHAR(1),
	@Tipo		INT,
	@Situacao	INT
AS
BEGIN
	BEGIN TRAN
		UPDATE Clientes	
			SET Nome			= @Nome,
				CPF				= @CPF,
				Sexo			= @Sexo,
				IdTipoCliente	= @Tipo,
				IdSituacaoCliente = @Situacao	
		WHERE Id = @Id
	COMMIT TRAN
END
GO

/* Deletar */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'DeletarCliente')
DROP PROCEDURE DeletarCliente
GO
CREATE PROCEDURE [dbo].[DeletarCliente]
	@Id	INT
AS
BEGIN
	BEGIN TRAN
		DELETE Clientes WHERE Id = @Id
	COMMIT TRAN
END
GO	

/* Listar Tipos de Clientes */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'ListarTiposClientes')
DROP PROCEDURE ListarTiposClientes
GO
CREATE PROCEDURE [dbo].[ListarTiposClientes]
AS
BEGIN
	SELECT Id, Descricao FROM ClientesTipos
END
GO

/* Listar Tipos de Clientes */
IF EXISTS(SELECT * FROM sysobjects WHERE NAME = 'ListarSituacoesClientes')
DROP PROCEDURE ListarSituacoesClientes
GO
CREATE PROCEDURE [dbo].[ListarSituacoesClientes]
AS
BEGIN
	SELECT Id, Descricao FROM ClientesSituacoes
END
GO
