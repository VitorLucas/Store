# Store

## Features

- Managment of Products in a store like: Insert, delete, update and list


## Tech

Store uses a number of open source projects to work properly:

- [Asp .net core version 5] - Backend base
- [Entity Framework version 5.0.11] - ORM
- [XUnit] - For test the application.


## Migration
To run Entity Framework Migration is just follow the steps
- Open Strore in Terminal

```sh
\github\StoreApp\Store> dotnet ef migrations add "MIGRATION NAME"

\github\StoreApp\Store> dotnet ef database update
