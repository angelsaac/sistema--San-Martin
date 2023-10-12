CREATE PROCEDURE ActualizarProductoS
	@id INT,
    @nombreProducto VARCHAR(50),
	@descripcionProducto VARCHAR(200),
	@precio DECIMAL(18, 4),
	@existencia DECIMAL(18, 4),
	 @TipoProducto_Id INT
AS
BEGIN
    SELECT
        @nombreProducto = @nombreProducto,
        @descripcionProducto =  @descripcionProducto,
        @precio =@precio,
        @existencia =@existencia,
        @TipoProducto_Id =  @TipoProducto_Id

    UPDATE Producto
    SET
        nombreProducto = @nombreProducto,
        descripcionProducto = @descripcionProducto,
        precio = @precio,
        existencia = @existencia,
        TipoProducto_Id = @TipoProducto_Id
    WHERE
        id = @id; 

END;

CREATE PROCEDURE DeleteProducto
    @ProductoID INT
AS
BEGIN
    UPDATE Producto
    SET
        status = 0,
        FechaEliminado = GETDATE()
    WHERE
        id = @ProductoID;
END;
-- EXEC DeleteProducto @ProductoID = 1;

CREATE PROCEDURE DeleteTipoProducto
    @TipoProductoID INT
AS
BEGIN
    UPDATE TiposProductos
    SET
        status = 0,
        FechaEliminado = GETDATE()
    WHERE
        id = @TipoProductoID;
END;
