CREATE PROCEDURE [dbo].[ClaveTemporal]
	@Nombre_Usuario VARCHAR(30),
	@Correo VARCHAR(100),
	@ClaveTemporal VARCHAR(30)
	
AS

BEGIN
  SET NOCOUNT ON

  DECLARE @ContrasenaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@ClaveTemporal));

  	 
  BEGIN TRANSACTION TRASA

  BEGIN TRY
	IF NOT EXISTS( SELECT * FROM dbo.Users WHERE @Nombre_Usuario=Nombre_Usuario) BEGIN
		SELECT -1 AS CodeError, 'El Usuario no se encuentra registrado!' AS MsgError
		END
	ELSE BEGIN
	UPDATE dbo.Users SET
			
			Clave	= @ContrasenaSHA1
			
		WHERE
			Nombre_Usuario = @Nombre_Usuario
	
  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError, CorreoEnvio, Pase From Correos Where IdCorreo=1
	END
  END TRY

	  BEGIN CATCH
		SELECT 
			   ERROR_NUMBER() AS CodeError,
			   ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA
  
  END CATCH

  END 
