CREATE PROCEDURE [dbo].[UsersInsertar]
		@Cedula VARCHAR(9), 
		@Nombre VARCHAR(250),
		@Primer_Apellido VARCHAR(250),
		@Segundo_Apellido VARCHAR(250), 
		@Nombre_Usuario VARCHAR(30), 
		@Clave VARCHAR(30),
		@IdRol INT
AS
BEGIN
	
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	DECLARE @ContrasenaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@Clave));

	IF EXISTS( SELECT * FROM dbo.Users WHERE @Cedula=Cedula) BEGIN
		SELECT -1 AS CodeError, 'Esta Cedula se encuentra registrada por favor ingresar otra cedula!' AS MsgError
	END
	ELSE IF EXISTS( SELECT * FROM dbo.Users WHERE @Nombre_Usuario=Nombre_Usuario) BEGIN
		SELECT -1 AS CodeError, 'Este Usuario se encuentra en uso por favor ingresar otro usuario!' AS MsgError
	END
	 ELSE BEGIN
		
		
		INSERT INTO	dbo.Users
		(
			 Cedula 
			,Nombre 
			,Primer_Apellido 
			,Segundo_Apellido 
			,Nombre_Usuario 
			,Clave
			,IdRol
		)
		VALUES
		(
			 @Cedula 
			,@Nombre 
			,@Primer_Apellido 
			,@Segundo_Apellido 
			,@Nombre_Usuario 
			,@ContrasenaSHA1
			,@IdRol
		)
		SELECT 0 AS CodeError, '' as MsgError
		END
		

		COMMIT TRANSACTION TRASA
		
	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH

END
