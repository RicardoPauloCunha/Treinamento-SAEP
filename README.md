# Configurando o Projeto

## Modelagem

1. Analisar materiais disponibilizados

2. Gerar modelagem DB
- usuario 1-possui-n tarefas 1-tem-n subTarefa 1-tem-n tipoSubTarefa

3. Criar script DDL

4. Cirar script DML

## Projeto

5. Criar projeto
- ASP .net > API com controlador

6. Baixar dependências
- EntityFrameWorkCore, EntityFrameWorkCore.SqlServer

7. Configurar startup
- MemomyCache, Session

8. Conectar banco de dado

9. Executar commando Scaffold

10. Terminar de implementar startup

11. Adicionar controlador MVC de ações API

12. Mudar controlador de inicio

## Dicas/Anotações

### Depedências
EntityframeWorkCore
EntityframeWorkCore.SqlServe

### Command
Scaffold-DbContext "connection-string" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Domains -ContextDir Contexts -Context NameContext

### Controller Razor
GET para exibir nas view
POST para enviar dados para o controller