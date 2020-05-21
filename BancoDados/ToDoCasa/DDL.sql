create database ToDo_Casa
go

use ToDo_Casa
go

create table Usuarios (
	id int not null primary key identity(1,1),
	email varchar(255) not null,
	senha varchar(255) not null
)

create table Tarefas (
	id int not null primary key identity(1,1),
	titulo varchar(255) not null,
	dataCriacao datetime not null,
)

create table Tipos_Subtarefas (
	id int not null primary key identity(1,1),
	nome varchar(255) not null
)

create table Subtarefas (
	id int not null primary key identity(1,1),
	descricao varchar(255) not null,
	concluido bit not null default 0,
	tipo_subtarefa_Id int not null,
	tarefa_Id int not null,
	foreign key (tipo_subtarefa_Id) references Tipos_Subtarefas(id),
	foreign key (tarefa_Id) references Tarefas(id)
)
