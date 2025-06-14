USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BaseDatos2')
BEGIN

CREATE DATABASE BaseDatos2;
PRINT 'Base de datos BaseDatos2 creada exitosamente.';
END

ELSE
BEGIN
PRINT 'La base de datos BaseDatos2 ya existe.';
END

GO