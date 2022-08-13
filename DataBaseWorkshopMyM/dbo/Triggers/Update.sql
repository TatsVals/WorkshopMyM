CREATE TRIGGER [Update]
		ON dbo.Users 
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO Bitacora_Movimientos (Nombre_Usuario, Fecha, Movimiento, Detalle)
		VALUES ('QUEMADO', GETDATE(), 'UPDATE', 'Usuario Actualizado')
	END
