# NET 8
+ ClassLibrary1: Class library
+ WebApplication1: ASP.NET Core Web App (Model-View-Controller)
+ ConsoleApp1: Console Application 
+ xUnitTestProject1: xUnit Test Project

```
dotnet new gitignore --force
dotnet tool update --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database update --environment Production
```

## SQL Server
+ Microsoft.Data.SqlClient
+ System.Data.SqlClient

## ClassLibrary1
+ 

## ConsoleApp1
+ Microsoft.Extensions.Configuration

## Zinger

A WinForms SQL client for generating C# query result classes, Dapper productivity
+ https://github.com/gtechsltn/Postulate.Zinger

## Poor Man's T-SQL Formatter

A WinForms Demo app for the free Poor Man's T-SQL Formatter library
+ https://github.com/gtechsltn/PoorMansTSqlFormatter

## Dapper.Contrib
+ Dapper
+ Dapper.Contrib

## EF Core
+ Need to Update EF Core Tools
```
dotnet tool update --global dotnet-ef
```
+ Migrations
```
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database update --environment Production
```

# References
+ CRUD with Blazor in .NET 8 🔥 Video & Code Inside 🚀
+ CRUD with Blazor in .NET 8 🔥 All Render Modes (SSR, Server, Wasm, Auto), Entity Framework & SQL Server
+ https://www.youtube.com/watch?v=w8imy7LT9zY
 
+ Integration Testing with Entity Framework Core and SQL Server
+ https://www.davepaquette.com/archive/2016/11/27/integration-testing-with-entity-framework-core-and-sql-server.aspx
+ https://github.com/AspNetMonsters/EntityFrameworkCoreIntegrationTest
+ https://github.com/gtechsltn/EntityFrameworkCoreIntegrationTest
