CREATE TRIGGER [Registro_Movimientos]
	ON dbo.Users 
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO Bitacora_Movimientos (Nombre_Usuario, Fecha, Movimiento, Detalle)
		VALUES ('QUEMADO', GETDATE(), 'INSERT', 'Usuario insertado')
	END
