INSERT INTO Usuarios VALUES('admin@gmail.com', '123')

BULK INSERT Tipos_Equipamentos
FROM 'C:\csv\tipo_equipamento.csv'
WITH (
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 1,
	CODEPAGE = 'acp'
)

GO

BULK INSERT Tipos_Defeitos
FROM 'C:\csv\defeito.csv'
WITH (
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 1,
	CODEPAGE = 'acp'
)

GO

BULK INSERT Registros_Defeitos
FROM 'C:\csv\registro_defeito.csv'
WITH (
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 1,
		CODEPAGE = 'acp'
)

GO



