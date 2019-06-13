# Fullstack Challenge API
Esta solução consome os dados da SWAPI e retorna com informações específicas sobre espécies e personages. 
Esta é a API do projeto, que é consumida pelo front-end em angular.

# Instruções para rodar o projeto
Instruções divididas entre API de autorização e Fullstack Challenge API
Siga as instruções em sequência.

## Requisitos

Windows:

1. .Net Core SDK 2.2 compatível com Visual Studio 2017 [link](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.107-windows-x64-installer)

Linux Ubuntu (no link tem como escolher a distro do linux, caso o seu não seja ubuntu):

1. .NET Core SDK 2.2 [link](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-current)

De preferência, abra o projeto utilizando o Visual Studio Code

## ASP.Net Core Identity Server (API de autorização)

A partir da pasta raiz, navegar para a pasta `"/fullstack-challenge"` executar os seguintes comandos no terminal:

1. `dotnet restore`;
2. `dotnet build`;

Em seguida, navegue para a pasta `"/fullstack-challenge/IdentityServer"` e execute o seguinte comando no terminal:

1. `dotnet run`;

Swagger disponível no link abaixo após executar o comando dotnet run:
1. http://localhost:5002/index.html

Para obter o access-token, envie uma requisição POST para o seguinte endpoint:
1. http://localhost:5002/api/authorization

E com o seguinte body:

```json
{
	"clientId": "fullstack-challenge-api",
	"clientSecret": "fsca",
	"scope":"fscapi"
}
```

## ASP.Net Core WEB API (Fullstack challenge API)

A partir da pasta raiz, navegue para a pasta `"/fullstack-challenge/API"` e execute os seguintes comandos para subir a API:

1. `dotnet run`;

Após isso é só usar a API.

Swagger disponível no link abaixo após executar o comando dotnet run:
1. http://localhost:5000/index.html

Os endpoints precisam de autorização para serem consumidos. Antes de enviar as requisições, deve-se obter um access-token pela API de autorização e enviá-los nos headers das requisições.  

Exemplo de chamadas:
1. http://localhost:5000/api/people/
1. http://localhost:5000/api/people/?page=2
1. http://localhost:5000/api/species/?search=human