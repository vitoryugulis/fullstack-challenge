# Instruções para rodar o projeto
Instruções divididas entre API e Front-end. 

## ASP.Net Core WEB API
Requisitos: baixar e instalar o .Net Core SDK 2.2.204 (https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.204-windows-x64-installer)
De preferência, utilize o Visual Studio Code para olhar o código. Por algum motivo, a classlib API não é identificada pelo Visual Studio 2017 (preciso identificar a raiz do problema, pode ser algo a ver com a versão do .Net Core SDK).

Dentro da pasta da aplicação "/fullstack-challenge", execute os seguintes comandos para subir a API:

1. dotnet restore;
2. dotnet build;
3. dotnet run.

Após isso é só usar a API.
Exemplo de chamadas:
1. https://localhost:5001/api/people/
2. https://localhost:5001/api/people/?page=1
3. https://localhost:5001/api/people/?page=2