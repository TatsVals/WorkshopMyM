CREATE PROCEDURE [dbo].[RolesCreate]
	@Rol VARCHAR(300),
	@Taller VARCHAR(50) = '',		
	@AccesoTaller BIT,
	@Personal VARCHAR(50) = '',		
	@AccesoPersonal BIT,
	@Bitacoras VARCHAR(50) = '',		
	@AccesoBitacoras BIT

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY

  	IF NOT EXISTS( SELECT * FROM dbo.Roles WHERE @Rol=Rol) BEGIN
	IF (@AccesoTaller = 1) BEGIN SET @Taller = 'Acceso a Taller' END
	ELSE BEGIN  SET @Taller = 'Sin Acceso a Taller' END
	IF (@AccesoPersonal = 1) BEGIN SET @Personal = 'Acceso a Personal' END
	ELSE BEGIN  SET @Personal = 'Sin Acceso a Taller' END
	IF (@AccesoBitacoras = 1) BEGIN SET @Bitacoras = 'Acceso a Bitacoras' END
	ELSE BEGIN  SET @Bitacoras = 'Sin Acceso a Taller' END

  INSERT INTO dbo.Roles
  (
     Rol
	 ,Taller
	 ,Personal
	 ,Bitacoras
  	 
  )
  VALUES
  (
      @Rol
	  ,@Taller
	  ,@Personal
	  ,@Bitacoras
	
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