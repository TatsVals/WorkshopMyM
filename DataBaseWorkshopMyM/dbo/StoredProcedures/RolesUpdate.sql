CREATE PROCEDURE [dbo].[RolesUpdate]
	@IdRol INT,
	@Rol VARCHAR(10),
	@Taller VARCHAR(50)= '',
	@AccesoTaller BIT

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY
  IF (@AccesoTaller = 1) BEGIN SET @Taller = 'Acceso Taller' END
	ELSE BEGIN  SET @Taller = 'Sin Acceso a Taller' END

  UPDATE dbo.Roles SET
      Rol = @Rol,
	  Taller = @Taller
	
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
