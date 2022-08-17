CREATE PROCEDURE [dbo].[RolesDelete]
  @IdRol INT

AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY
  IF ( @IdRol != 1) BEGIN
   DELETE FROM dbo.Roles
   WHERE IdRol = @IdRol

  
  SELECT 0 AS CodeError, '' AS MsgError

  END 
  ELSE BEGIN 
  SELECT -1 AS CodeError, 'Este Rol no se puede borrar' AS MsgError


		
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