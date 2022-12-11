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
#### Start server
```
$ dotnet run
```
Server listens on `http://localhost:5236`. 
Perform GET, POST, PUT, DELETE on API `http://localhost:5236/api/Products/`. 
- GET response
```
{
  "code": "200",
  "message": "Success",
  "responseData": [
    {
      "id": "cef4ab44-0202-4683-b6a7-de7f2bfdbd07",
      "name": "macbook",
      "slug": "macbook",
      "description": "Macbook 14 Pro Max",
      "quantity": 10,
      "price": 3000,
      "manufactured_date": null
    },
    {
      "id": "8a677e02-3bbd-4209-85e1-f3595ac9ba24",
      "name": "iphone",
      "slug": "iphone",
      "description": "iPhone 15 Pro Max",
      "quantity": 10,
      "price": 1500,
      "manufactured_date": null
    },
    {
      "id": "3be8b7cf-561d-43ed-a6a9-634c474bf5b1",
      "name": "apple watch",
      "slug": "apple-watch",
      "description": "Apple watch series 8",
      "quantity": 30,
      "price": 1000,
      "manufactured_date": null
    }
  ]
}
```
