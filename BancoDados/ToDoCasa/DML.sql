use ToDo_Casa
go

insert into Usuarios(email, senha)
values('admin@gmail.com', 'senha')

insert into Tarefas(titulo, dataCriacao)
values('Tarefa 1', GETDATE()),
('Tarefa 2', GETDATE()),
('Tarefa 3', GETDATE())

insert into Tipos_Subtarefas(nome)
values('Tipo 1'),
('Tipo 2'),
('Tipo 3'),
('Tipo 4')

insert into Subtarefas(descricao, tarefa_Id, tipo_subtarefa_Id)
values('Subtarefa 1', 1, 4),
('Subtarefa 2', 3, 2),
('Subtarefa 3', 2, 3)

select * from Usuarios
select * from Tarefas
select * from Tipos_Subtarefas
select * from Subtarefas