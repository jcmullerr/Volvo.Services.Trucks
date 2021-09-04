# Volvo.Services.Trucks
    Esta aplicação é uma web api construida em .net core, com o propósito de gerenciar 
    (criar, atualizar, excluir e buscar) dados sobre caminhões cadastrados.
## Pré requisitos para executar localmente
    1 - sdk .net 5 instalado
    2 - sql server local, ou uma base disponivel para guardar os dados
    
## Passos para executar a aplicação
    1 - Execute o comando dotnet restore dentro do diretório raiz da aplicação
    2 - Execute o comando dotnet build dentro do diretório raiz da aplicação
    2 - Altere o appSettings.json com a string de conexão de sua instância do sqlServer
    3 - Execute o comando dotnet run no diretório raiz da aplicacão

## Passos para executar os teste automatizados
    1 - Execute o comando dotnet test dentro do diretório raiz da aplicação