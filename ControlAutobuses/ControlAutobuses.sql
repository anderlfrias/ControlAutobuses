CREATE DATABASE ControlAutobuses;

USE ControlAutobuses;

CREATE TABLE Roles(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Nombre NVARCHAR(20),
	NombreNormal NVARCHAR(30)
);

CREATE TABLE Usuarios(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Nombre NVARCHAR(50),
	Usuario NVARCHAR(12) UNIQUE NOT NULL,
	Password NVARCHAR(255) NOT NULL,
	RoleId NVARCHAR(255) NOT NULL
	CONSTRAINT FK_Usuario_Role FOREIGN KEY (RoleId) REFERENCES Roles (Id)
);

CREATE TABLE Autobuses(
	Id NVARCHAR(255) PRIMARY KEY,
	Codigo AS('COD-'+RIGHT(Id,4)),
	Marca NVARCHAR(30),
	Modelo NVARCHAR(30),
	Placa NVARCHAR(10) UNIQUE NOT NULL,
	Color NVARCHAR(25),
	Anio SMALLINT,
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
	@Anio SMALLINT,
	@Asignado BIT
AS
	INSERT INTO Autobuses (Id, Marca, Modelo, Placa, Color, Anio, Asignado)
	VALUES (@Id, @Marca, @Modelo, @Placa, @Color, @Anio, @Asignado);

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
	@Anio SMALLINT,
	@Asignado BIT
AS
	UPDATE Autobuses
	SET Marca = @Marca,
		Modelo = @Modelo,
		Color = @Color,
		Anio = @Anio,
		Asignado = @Asignado
	WHERE Id = @Id;

GO
CREATE PROCEDURE SP_ELIMINAR_AUTOBUS
	@Id NVARCHAR(255)
AS
	DELETE FROM Autobuses
	WHERE Id = @Id;

GO

--STORE PROCEDURE PARA RUTAS
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

GO

--STORE PROCEDURE PARA CHOFERES
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


GO

--STORE PROCEDURE PARA MOSTRAR SOLO A LOS CHOFERES, RUTAS Y AUTOBUSES SIN ASIGNAR
GO
CREATE PROCEDURE SP_AUTOBUSES_DISPONIBLES
AS
	SELECT *
	FROM Autobuses
	WHERE Asignado = 0;

GO
CREATE PROCEDURE SP_RUTAS_DISPONIBLES
AS
	SELECT * 
	FROM Rutas
	WHERE Asingnado = 0;

GO
CREATE PROCEDURE SP_CHOFERES_DISPONIBLES
AS
	SELECT *
	FROM Choferes
	WHERE RutaId = NULL
		OR AutobusId = NULL

GO

--STORE PROCEDURE PARA ROLES
GO
CREATE PROCEDURE SP_GET_ROLES
AS
	SELECT *
	FROM Roles
;

GO
CREATE PROCEDURE SP_GET_ROLE_BY_ID
	@Id NVARCHAR(255)
AS
	SELECT *
	FROM Roles
	WHERE Id = @Id;


GO
CREATE PROCEDURE SP_FIND_ROLE_BY_NAME
	@Nombre NVARCHAR(20)
AS
	SELECT * 
	FROM Roles
	WHERE Nombre = @Nombre;
GO
--STORE PROCEDURE PARA USUARIOS
CREATE PROCEDURE SP_REGISTER_USUARIO
	@Id NVARCHAR(255),
	@Nombre NVARCHAR(50),
	@Usuario NVARCHAR(12),
	@Password NVARCHAR(255),
	@RoleId NVARCHAR(255)
AS
	INSERT INTO Usuarios (Id, Nombre, Usuario, Password, RoleId)
		VALUES (@Id, @Nombre, @Usuario, @Password, @RoleId);

GO
CREATE PROCEDURE SP_CHANGE_USER_ROLE
	@Id NVARCHAR(255),
	@RoleId NVARCHAR(255)
AS
	UPDATE Usuarios
	SET RoleId = @RoleId
	WHERE Id = @Id;

--STORE PROCEDURE PARA VERIFICAR USUARIO
CREATE PROCEDURE SP_FIND_USER_BY_USERNAME
	@Usuario NVARCHAR(12)
AS
	SELECT u.Id, u.Codigo, u.Nombre, u.Usuario, u.Password, r.Nombre AS Role 
	FROM Usuarios u
	INNER JOIN Roles r ON r.Id = u.RoleId
	WHERE u.Usuario = @Usuario;

GO
CREATE PROCEDURE SP_FIND_USER_BY_ID
	@Usuario NVARCHAR(12)
AS
	SELECT u.Id, u.Codigo, u.Nombre, u.Usuario, u.Password, r.Nombre AS Role 
	FROM Usuarios u
	INNER JOIN Roles r ON r.Id = u.RoleId
	WHERE u.Id = @Usuario;

GO


--INSERTS DE PRUEBA
INSERT INTO Autobuses (Id, Marca, Modelo, Placa, Color, Anioo, Asignado)
	   VALUES ('1234', 'Toyota', 'Camry', 'A010203', 'Blanco', 2015, 0);

INSERT INTO Rutas (Id, Nombre, Descripcion, Asingnado)
		VALUES ('1234', 'Charles', 'Ruta desde villa mella hasta el puente Juan Carlos', 0);

INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula, AutobusId, RutaId)
	VALUES ('1234', 'Anderson', 'Frias', '03-16-2001', '40219174808', NULL, NULL);

INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula, AutobusId, RutaId)
	VALUES ('1235', 'Leonel', 'Acosta', '03-16-2001', '40219174807', NULL, NULL);

INSERT INTO Choferes (Id, Nombre, Apellido, BirthDate, Cedula)
	VALUES ('123YU8U', 'Leonel', 'Acosta', '03-16-2001', '40219174809');

INSERT INTO Roles(Id, Nombre, NombreNormal)
	VALUES ('71B7F713-A148-4752-A750-CD3C04D9FB07', 'admin', 'Administrador');

INSERT INTO Roles(Id, Nombre, NombreNormal)
	VALUES ('04EFAA89-E877-47AF-8B8A-33689461844C', 'user', 'Usuario General');

INSERT INTO Roles(Id, Nombre, NombreNormal)
	VALUES ('F3015771-8AF2-47E2-9AE6-F33635A679B4', 'root', 'ROOT');

INSERT INTO Usuarios(Id, Nombre, Usuario, Password, RoleId)
	VALUES ('C144EB70-4FAE-4CC2-AC9F-43A404D75F14', 'ADMINISTRADOR', 'admin', 'MQAyADMANAA=', '71B7F713-A148-4752-A750-CD3C04D9FB07');


GO
--Selects
SELECT * FROM Autobuses;
SELECT * FROM Rutas;
SELECT * FROM Choferes;
SELECT * FROM Roles;
SELECT * FROM Usuarios;

SELECT u.Id, u.Codigo, u.Nombre, u.Usuario, u.Password, r.Nombre AS Role 
FROM Usuarios u
INNER JOIN Roles r ON r.Id = u.RoleId;

SELECT * 
FROM Roles
WHERE Nombre = 'user';