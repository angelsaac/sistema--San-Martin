IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DBPruebaTecnicaAngel')
BEGIN
    CREATE DATABASE DBPruebaTecnicaAngel;
END;

USE DBPruebaTecnicaAngel; 

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'TiposProductos')
BEGIN
	CREATE TABLE TiposProductos(
		Id Int not null identity(1,1) primary key,
		nombreTipoProducto Varchar(50) NOT NULL,
		descripcionTipoProducto varchar(200) NOT NULL,
		FechaRegistro Datetime default getdate(),
		FechaEliminado datetime default null,
    status int default 1
	); 
END;

IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'Producto')
BEGIN
	CREATE TABLE Producto(
		id Int not null identity(1,1) primary key,
		NombreProducto varchar(50) NOT NULL,
		DescripcionProducto varchar(200),
		Precio Decimal(18,4) NOT NULL,
		Existencia Decimal(18,4) NOT NULL, 
		TipoProducto_Id Int references TiposProductos(Id) ,
		FechaRegistro DateTime default getdate() ,
		FechaEliminado DateTime default null,
    status int default 1
	);
END;
/*
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
EXEC DeleteProducto @ProductoID = 1;

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
EXEC DeleteTipoProducto @TipoProductoID = 1;

*/
/*
insert into TiposProductos(nombreTipoProducto, descripcionTipoProducto) values ('Electrodomesticos', 'Electrodomesticos para el hogar')
select * from Producto;
select * from TiposProductos;
update Producto set status = 1, FechaEliminado = NULL Where status = 0
insert into Producto values ('Ramo de flores', 'Corona de flores', 200.02, 400, 1, getdate(), getdate())
*/
