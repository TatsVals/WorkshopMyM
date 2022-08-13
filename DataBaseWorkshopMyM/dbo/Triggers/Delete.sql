CREATE TRIGGER [Delete]
	ON dbo.Users 
	AFTER DELETE
	AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO Bitacora_Movimientos (Nombre_Usuario, Fecha, Movimiento, Detalle)
		VALUES ('QUEMADO', GETDATE(), 'DELETE', 'Usuario eliminado')
	END
