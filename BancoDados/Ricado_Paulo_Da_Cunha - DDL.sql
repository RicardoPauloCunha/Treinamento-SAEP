CREATE DATABASE Lan_House
GO

USE Lan_House
GO

CREATE TABLE Tipos_Defeitos (
	id int NOT NULL IDENTITY(1,1),
	nome varchar(100) NOT NULL,
	PRIMARY KEY(id)
)

CREATE TABLE Tipos_Equipamentos (
	id int NOT NULL IDENTITY(1,1),
	nome varchar(100) NOT NULL,
	PRIMARY KEY(id)
)

CREATE TABLE Registros_Defeitos (
	id int NOT NULL IDENTITY(1,1),
	Data_Defeito DATETIME2 NOT NULL,
	Tipo_Equipamento_Id INT NOT NULL,
	Tipo_Defeito_Id INT NOT NULL,
	Observacao varchar(100) NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY (Tipo_Equipamento_Id) REFERENCES Tipos_Equipamentos(id),
	FOREIGN KEY (Tipo_Defeito_Id) REFERENCES Tipos_Defeitos(id),
)

CREATE TABLE Usuarios (
	id int NOT NULL IDENTITY(1,1),
	email varchar(100) NOT NULL,
	senha varchar(100) NOT NULL,
	PRIMARY KEY(id)
)