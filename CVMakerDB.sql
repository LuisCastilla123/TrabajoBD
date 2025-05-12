USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CVMakerDB')
BEGIN

CREATE DATABASE CVMakerDB;
PRINT 'Base de datos CVMakerDB creada exitosamente.';
END

ELSE
BEGIN
PRINT 'La base de datos CVMakerDB ya existe.';
END

GO