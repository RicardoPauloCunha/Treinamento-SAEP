USE ToDoCasa
GO

INSERT INTO Usuarios(Email, Senha)
VALUES('admin@gmail.com', 'senha')

INSERT INTO Tarefas(Titulo, DataCriacao)
VALUES('Tarefa 1', GETDATE()),
('Tarefa 2', GETDATE()),
('Tarefa 3', GETDATE())

INSERT INTO TiposSubtarefas(Nome)
VALUES('Tipo 1'),
('Tipo 2'),
('Tipo 3'),
('Tipo 4')

INSERT INTO Subtarefas(Descricao, TarefaId, TipoSubtarefaId)
VALUES('Subtarefa 1', 1, 4),
('Subtarefa 2', 3, 2),
('Subtarefa 3', 2, 3)

SELECT * FROM Usuarios
SELECT * FROM Tarefas
SELECT * FROM TiposSubtarefas
SELECT * FROM Subtarefas