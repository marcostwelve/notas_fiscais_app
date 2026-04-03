<h1 align="center">Notas Fiscais App</h1>



 ## Simples projeto de buscas de notas fiscais e gerador em XML.

## 🔥 Introdução

Web API foi criada com .net versão 8 e Console em .net Framework 4.8.1

### ⚙️ Pré-requisitos
* .Net Core versão 8.0 [.Net Core 8.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* .Net Framework versão 4.8.1 [.Net Framework versão 4.8.1 Download](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net481)
* Dapper [Documentação]([https://learn.microsoft.com/pt-br/ef/](https://www.learndapper.com/))
* Visual studio 2022, ou IDE que tenha suporte ao .Net 8.0 [Visual Studio 2022 Download](https://visualstudio.microsoft.com/pt-br/downloads/)
* SQL Server [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
  


### 🔨 Guia de instalação

Para utilizar este projeto, necessário instalar o Dapper e configurar o banco de dados no arquivo appsettings.json

Etapas para criar Console e Web API:

Passo 1 Criar projeto (Console e Web API)
```bash
dotnet new console -n NotaFiscal.ConsoleApp
dotnet new webapi -n NotaFiscal.Api
```
Passo 2 Instalar Pacotes:
```bash
dotnet add package Dapper
dotnet add package System.Data.SqlClient
```

# Executando a Aplicação 🌐


Para executar a aplicação, digite o seguinte comando

```bash
dotnet run
```
