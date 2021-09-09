# .Net Core Worker com Docker

Esse é um breve projeto para termos os conceitos de como um worker básico funciona. Nesse exemplo eu emulo um processamento em massa com um Task.Delay que está configurado no appsettings.json. 
O cíclo do worker é sua execucão inicial, delay do processamento e encerramento do mesmo.

## Tecnologia utilizada

[.Net 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
[Docker](https://www.docker.com/)

## Execução via Docker:

Primeiro faremos o build:
```
docker build -t wrk-demo .
```

Depois faremos o run:

```
docker run wrk-demo
```
