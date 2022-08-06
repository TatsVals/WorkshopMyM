CREATE PROCEDURE [dbo].[UsersInsertar]
		@Cedula VARCHAR(9), 
		@Nombre VARCHAR(250),
		@Primer_Apellido VARCHAR(250),
		@Segundo_Apellido VARCHAR(250), 
		@Nombre_Usuario VARCHAR(30), 
		@Clave VARCHAR(30)
AS
BEGIN
	
	SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		INSERT INTO	dbo.Users
		(
			 Cedula 
			,Nombre 
			,Primer_Apellido 
			,Segundo_Apellido 
			,Nombre_Usuario 
			,Clave	
		)
		VALUES
		(
			 @Cedula 
			,@Nombre 
			,@Primer_Apellido 
			,@Segundo_Apellido 
			,@Nombre_Usuario 
			,@Clave	
		)

		COMMIT TRANSACTION TRASA
		SELECT 0 AS CodeError, '' as MsgError
	END TRY

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeRrror,
			ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END CATCH

END
