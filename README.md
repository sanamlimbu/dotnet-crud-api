# dotnet-crud-api
Simple REST APIs for CRUD operations using .NET, Entity Framework, and PostgreSQL.
### _Dev dependencies_
- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://docs.docker.com/get-docker/)
- [Entity Framework Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
    ```
    $ dotnet tool install --global dotnet-ef
    ```
#### Run PostgreSQL
```
$ docker run -d --name dotnet-crud-api-db -p 5455:5432 \ 
-e POSTGRES_USER=dotnet-crud-api -e POSTGRES_PASSWORD=devdev \
-e POSTGRES_DB=dotnet-crud-api postgres:15-alpine
```
#### Update database
```
$ dotnet ef database update
```
