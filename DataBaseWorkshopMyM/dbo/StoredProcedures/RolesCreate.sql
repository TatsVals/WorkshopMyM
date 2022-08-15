CREATE PROCEDURE [dbo].[RolesCreate]
	@Rol VARCHAR(300)

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

  	IF NOT EXISTS( SELECT * FROM dbo.Roles WHERE @Rol=Rol) BEGIN
  INSERT INTO dbo.Roles
  (
     Rol
  	 
  )
  VALUES
  (
      @Rol		  
	
  )

    SELECT 0 AS CodeError, '' AS MsgError
	END
  ELSE BEGIN 
		
			SELECT -1 AS CodeError, 'Este Rol se encuentra en uso por favor ingresar otro Rol!' AS MsgError


		END

  COMMIT TRANSACTION TRASA



  END TRY

	  BEGIN CATCH
		SELECT 
			   ERROR_NUMBER() AS CodeError,
			   ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA
  
  END CATCH

  END 