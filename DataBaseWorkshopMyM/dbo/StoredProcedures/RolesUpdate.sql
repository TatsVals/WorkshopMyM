CREATE PROCEDURE [dbo].[RolesUpdate]
	@IdRol INT,
	@Rol VARCHAR(10),
	@Taller VARCHAR(50)= '',
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
  IF (@AccesoTaller = 1) BEGIN SET @Taller = 'Acceso a Taller' END
	ELSE BEGIN  SET @Taller = 'Sin Acceso a Taller' END
  IF (@AccesoPersonal = 1) BEGIN SET @Personal = 'Acceso a Personal' END
	ELSE BEGIN  SET @Personal = 'Sin Acceso a Taller' END
  IF (@AccesoBitacoras = 1) BEGIN SET @Bitacoras = 'Acceso a Bitacoras' END
	ELSE BEGIN  SET @Bitacoras = 'Sin Acceso a Taller' END

  UPDATE dbo.Roles SET
      Rol = @Rol,
	  Taller = @Taller,
	  Personal = @Personal,
	  Bitacoras = @Bitacoras

  WHERE
     IdRol = @IdRol

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
