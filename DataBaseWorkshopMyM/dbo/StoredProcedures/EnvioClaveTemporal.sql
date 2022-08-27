CREATE PROCEDURE [dbo].[EnvioClaveTemporal]	
	@Nombre_Usuario VARCHAR(30),
	@Correo VARCHAR(100)
AS

BEGIN
  SET NOCOUNT ON

  DECLARE @ClaveTemporal VARCHAR(30) = FLOOR(RAND()*(1000000-1)+1);
  DECLARE @ContrasenaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@ClaveTemporal));

  	 

  DECLARE @BODY varchar(max) ='<!DOCTYPE html>
                <html lang="en">
                <head>
                <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width", initial-scale=1.0">
                </head>
                <body>                
		<h3>Tu clave temporal es: ' +@ClaveTemporal+ ' </h3>

                </body>
                </html>';
  BEGIN TRANSACTION TRASA

  BEGIN TRY


  	 Exec msdb.dbo.sp_send_dbmail
		@profile_name='EmailClave',
		@recipients=@Correo,
		--@copy_recipients='correo1@hotmail.com; correo2@outlook.com',
		@body=@BODY,
		@body_format='HTML',
		@subject='Clave Temporal'


	UPDATE dbo.Users SET
			
			Clave	= @ContrasenaSHA1
			
		WHERE
			Nombre_Usuario = @Nombre_Usuario

	

  
		
  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

	  BEGIN CATCH
		SELECT 
			   ERROR_NUMBER() AS CodeError,
			   ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA
  
  END CATCH

  END 
