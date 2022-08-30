CREATE PROCEDURE [dbo].[RolesDelete]
  @IdRol INT
  ,@UsuarioLogin VARCHAR(50)
  ,@Rol VARCHAR(50)
AS
 BEGIN
  SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

  BEGIN TRY
  IF ( @IdRol != 1) BEGIN
   DELETE FROM dbo.Roles
   WHERE IdRol = @IdRol

  INSERT INTO	dbo.Bitacora_Movimientos
		(
			 Nombre_Usuario
			,Fecha
			,Movimiento
			,Tabla
		    ,Detalle
		)
		VALUES
		(
			 @UsuarioLogin
			,GETDATE()
			, 'DELETE'
			, 'Roles' 
			, 'Rol: ' + @Rol  + ' eliminado'
		)
		
 

  END 
  ELSE BEGIN 
  SELECT -1 AS CodeError, 'Este Rol no se puede borrar' AS MsgError

  
  END
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