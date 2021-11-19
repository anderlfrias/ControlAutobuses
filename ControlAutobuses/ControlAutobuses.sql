CREATE DATABASE ControlAutobuses;

USE ControlAutobuses;

CREATE TABLE Autobuses(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Marca NVARCHAR(30),
	Modelo NVARCHAR(30),
	Placa NVARCHAR(10) UNIQUE NOT NULL,
	Color NVARCHAR(25),
	Año SMALLINT,
	Asignado BIT
);

CREATE TABLE Rutas(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Nombre NVARCHAR(30) NOT NULL,
	Descripcion NVARCHAR(50),
	Asingnado BIT,
);

CREATE TABLE Choferes(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Nombre NVARCHAR(50) NOT NULL,
	Apellido NVARCHAR(50),
	BirthDate DATETIME,
	Cedula NVARCHAR(11) UNIQUE NOT NULL,
	AutobusId NVARCHAR(255) NULL,
	RutaId NVARCHAR(255) NULL,
	--CONSTRAINTS
	CONSTRAINT FK_Chofer_Autobus FOREIGN KEY (AutobusId) REFERENCES Autobuses (Id),
	CONSTRAINT FK_Chofer_Ruta FOREIGN KEY (RutaId) REFERENCES Rutas (Id)
);

--STORE PROCEDURE PARA AUTOBUSES
GO
CREATE PROCEDURE SP_CREATE_AUTOBUS
	@Id NVARCHAR(255),
	@Marca NVARCHAR(30),
	@Modelo NVARCHAR(30),
	@Placa NVARCHAR(10),
	@Color NVARCHAR(25),
	@Año SMALLINT,
	@Asignado BIT
AS
	INSERT INTO Autobuses (Id, Marca, Modelo, Placa, Color, Año, Asignado)
	VALUES (@Id, @Marca, @Modelo, @Placa, @Color, @Año, @Asignado);

GO
CREATE PROCEDURE SP_FILTRAR_AUTOBUS
	@FILTRAR NVARCHAR(20)
AS
	SELECT *
	FROM Autobuses
	WHERE Marca LIKE '%'+@Filtrar+'%'
		OR Modelo LIKE '%'+@Filtrar+'%'
		OR Placa LIKE '%'+@Filtrar+'%'
		OR Año LIKE '%'+@Filtrar+'%'

GO
CREATE PROCEDURE SP_FIND_AUTOBUS_BY_ID
	@Id NVARCHAR(255)
AS
	SELECT *
	FROM Autobuses
	WHERE Id = @Id

GO
CREATE PROCEDURE SP_MODIFICAR_AUTOBUS
	@Id NVARCHAR(255),
	@Marca NVARCHAR(30),
	@Modelo NVARCHAR(30),
	@Placa NVARCHAR(10),
	@Color NVARCHAR(25),
	@Año SMALLINT,
	@Asignado BIT
AS
	UPDATE Autobuses
	SET Marca = @Marca,
		Modelo = @Modelo,
		Color = @Color,
		Año = @Año,
		Asignado = @Asignado
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_ELIMINAR_AUTOBUS
	@Id NVARCHAR(255)
AS
	DELETE FROM Autobuses
	WHERE Id = @Id;

--STORE PROCEDURE PARA RUTAS
GO
CREATE PROCEDURE SP_CREATE_RUTA
	@Id NVARCHAR(255),
	@Nombre NVARCHAR(30),
	@Descripcion NVARCHAR(50),
	@Asingnado BIT
AS
	INSERT INTO Rutas (Id, Nombre, Descripcion, Asingnado)
		VALUES (@Id, @Nombre, @Descripcion, @Asingnado);

GO
CREATE PROCEDURE SP_FILTRAR_RUTAS
	@FILTRO NVARCHAR(20)
AS
	SELECT * 
	FROM Rutas
	WHERE Nombre LIKE '%'+@FILTRO+'%';

GO
CREATE PROCEDURE SP_FIND_RUTA_BY_ID
	@Id NVARCHAR(255)
AS
	SELECT *
	FROM Rutas
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_MODIFICAR_RUTA
	@Id NVARCHAR(255),
	@Nombre NVARCHAR(30),
	@Descripcion NVARCHAR(50),
	@Asingnado BIT
AS
	UPDATE Rutas
	SET Nombre = @Nombre,
		Descripcion = @Descripcion,
		Asingnado = @Asingnado
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_ELIMINAR_RUTA
	@Id NVARCHAR(255)
AS
	DELETE FROM Rutas
	WHERE Id = @Id;

--STORE PROCEDURE PARA CHOFERES
GO
CREATE PROCEDURE SP_CREATE_CHOFER
	@Id NVARCHAR(255),
	@Nombre NVARCHAR(50),
	@Apellido NVARCHAR(50),
	@BirthDate DATETIME,
	@Cedula NVARCHAR(11),
	@AutobusId NVARCHAR(255),
	@RutaId NVARCHAR(255)
AS
	INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula, AutobusId, RutaId)
	VALUES (@Id, @Nombre, @Apellido, @BirthDate, @Cedula, @AutobusId, @RutaId);

GO
CREATE PROCEDURE SP_FILTRAR_CHOFERES
	@FILTRO NVARCHAR(20)
AS
	SELECT *
	FROM Choferes
	WHERE Nombre LIKE '%'+@FILTRO+'%'
		OR Apellido LIKE '%'+@FILTRO+'%'
		OR Cedula LIKE '%'+@FILTRO+'%';

GO
CREATE PROCEDURE SP_FIND_CHOFER_BY_ID
	@Id NVARCHAR(255)
AS
	SELECT *
	FROM Choferes
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_MODIFICAR_CHOFER
	@Id NVARCHAR(255),
	@Nombre NVARCHAR(50),
	@Apellido NVARCHAR(50),
	@BirthDate DATETIME,
	@Cedula NVARCHAR(11),
	@AutobusId NVARCHAR(255),
	@RutaId NVARCHAR(255)
AS
	UPDATE Choferes
	SET Nombre = @Nombre,
		Apellido = @Apellido,
		BirthDate = @BirthDate,
		Cedula = @Cedula,
		AutobusId = @AutobusId,
		RutaId = @RutaId
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_ELIMINAR_CHOFER
	@Id NVARCHAR(255)
AS
	DELETE FROM Choferes
	WHERE Id = @Id;

--INSERTS DE PRUEBA
INSERT INTO Autobuses (Id, Marca, Modelo, Placa, Color, Año, Asignado)
	   VALUES ('1234', 'Toyota', 'Camry', 'A010203', 'Blanco', 2015, 0);

INSERT INTO Rutas (Id, Nombre, Descripcion, Asingnado)
		VALUES ('1234', 'Charles', 'Ruta desde villa mella hasta el puente Juan Carlos', 0);

INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula, AutobusId, RutaId)
	VALUES ('1234', 'Anderson', 'Frias', '03-16-2001', '40219174808', NULL, NULL);

INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula, AutobusId, RutaId)
	VALUES ('1235', 'Leonel', 'Acosta', '03-16-2001', '40219174807', NULL, NULL);

--Selects
SELECT * FROM Autobuses;
SELECT * FROM Rutas;
SELECT * FROM Choferes;