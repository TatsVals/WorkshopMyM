CREATE PROCEDURE [dbo].[Login]
@Nombre_Usuario VARCHAR(250),
@Clave VARCHAR(250)
AS 
BEGIN
SET NOCOUNT  ON


DECLARE @ContrasenaSHA1 VARBINARY(MAX)=(SELECT HASHBYTES('SHA1',@Clave));

IF NOT EXISTS(SELECT * FROM Users WHERE Nombre_Usuario=@Nombre_Usuario) BEGIN
	SELECT -1 AS CodeError, 'El nombre del usuario no existe' AS MsgError

END

ELSE IF  NOT EXISTS( SELECT * FROM Users WHERE Nombre_Usuario=@Nombre_Usuario and Clave=@ContrasenaSHA1 ) BEGIN
 
 SELECT -1 AS CodeError, 'La contraseña es incorrecta por favor volver a intentar!' AS MsgError
END
ELSE BEGIN


	SELECT 
	0 AS CodeError,
	IdUsuario,
	Nombre_Usuario,
	Nombre,
	IdRol
	FROM Users 
		WHERE Nombre_Usuario=@Nombre_Usuario and Clave=@ContrasenaSHA1 

END



	

END