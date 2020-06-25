# BeerService

Nesta aplicação é possível realizar o cadastro, edição, exclusão, consulta e listagem de cervejas. A tela inicial exibe uma listagem com as cervejas já cadastradas e possibilita incluir um novo registro clicando no botão "Cadastrar". presente no canto superior direito.
Também está disponível a opção "Documentação", que direciona para a documentação Swagger da aplicação. A opção "visualizar" dá uma visão geral da cerveja selecionada, exibindo suas informações à esquerda e sua imagem à direita.

## Iniciando

Para inicializar a aplicação, é necessário cumprir com os seguintes pré-requisitos

### Requisitos

* SDK .NET Core 3.1;
* PostgreSQL 12.3 ou superior. As informações para conexão estão disponíveis no AppSettings.json;
* Node.JS 12 ou superior;

### Execução

Após atender os pré-requisitos, basta executá-lo através do seguinte comando: 
```
dotnet run --project .\src\BeerService.WebApi\ --urls=https://localhost:44314/
```
Também é possível executá-lo no Visual Studio 2019 após clonar o repositório.

## Informações Gerais

A seguir, as bibliotecas e tecnologias utilizadas para desenvolver a aplicação:

### Tecnologia
* ASP.NET Core 3.1
* PostgreSQL 12.3
* Entity Framework Core para PostgreSQL 3.1.4
* Angular 8
* AutoMapper 9.0.0
* Fluent Validation Core 8.6.2
* MediatR 8.0.1
* NSubstitute 4.2.2
* Swagger 5.0.0
