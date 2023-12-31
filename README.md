﻿# NET 8
+ .NET Core 7.0
+ .NET Core 8.0
+ ASP.NET Core MVC
+ ASP.NET Core Web API
+ EF Core
+ SQL Server
+ ClassLibrary1: Class library
+ ConsoleApp1: Console Application
+ WebApplication1: ASP.NET Core Web App (Model-View-Controller)
+ xUnitTestProject1: xUnit Test Project
+ BlazorServerApp1: Blazor Server App
+ BlazorWebAssembly1: Blazor Web Assembly

## NuGet
+ Microsoft.Data.SqlClient
+ Microsoft.EntityFrameworkCore.Design
+ Microsoft.EntityFrameworkCore.SqlServer
+ Microsoft.EntityFrameworkCore.Tools
+ Microsoft.Extensions.Configuration
+ Microsoft.Extensions.Configuration.FileExtensions     <- .SetBasePath(Directory.GetCurrentDirectory())
+ Microsoft.Extensions.Configuration.Json               <- .AddJsonFile("appsettings.json")


## Adding Dependency Injection to a Console App in .Net 7
+ https://pmichaels.net/di-console-app/
```
Install-Package Microsoft.Extensions.DependencyInjection
Install-Package Microsoft.Extensions.Hosting
```

## Connection Strings
```
Server=.;Database=mssql;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;
Server=localhost;Database=mssql;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;
Server=(localdb)\\v11.0;Database=mssql;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;
Server=(localdb)\\ProjectsV13;Database=mssql;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;
Server=(localdb)\\mssqllocaldb;Database=mssql;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;
```

## DbContext
```
public class MonsterContext : DbContext
{
    public MonsterContext(DbContextOptions<MonsterContext> options) : base(options)
    {
    }

    public DbSet<Monster> Monsters { get; set; }
}
```

## IDesignTimeDbContextFactory
```
public class MonsterContextFactory : IDesignTimeDbContextFactory<MonsterContext>
{
    public MonsterContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<MonsterContext>();
        var connectionString = configuration.GetConnectionString(nameof(MonsterContext));
        dbContextOptionsBuilder.UseSqlServer(connectionString);

        return new MonsterContext(dbContextOptionsBuilder.Options);
    }
}
```

## Git Ignore
```
dotnet new gitignore --force
```

## SQL Server
+ Microsoft.Data.SqlClient
+ System.Data.SqlClient

## ClassLibrary1
+ Microsoft.Extensions.Configuration
+ Microsoft.Extensions.Configuration.FileExtensions
+ Microsoft.Extensions.Configuration.Json
+ Microsoft.EntityFrameworkCore.Design
+ Microsoft.EntityFrameworkCore.SqlServer
+ Microsoft.EntityFrameworkCore.Tools

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

## Environment
```
dotnet ef database update --environment Development
dotnet ef database update --environment Staging
dotnet ef database update --environment Production
```

## EF Core Tools

Need to Update EF Core Tools
```
dotnet tool update --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef database update --environment Development
dotnet ef database update --environment Staging
dotnet ef database update --environment Production
```

## Paging, Sorting, Searching
+ https://code-maze.com/paging-aspnet-core-webapi/
+ https://codewithmukesh.com/blog/pagination-in-aspnet-core-webapi/
+ https://www.marcoalbasini.com/2021/05/search-pagination-and-sorting-in-asp-net-core/?lang=en
+ https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-7.0
+ https://www.codeproject.com/Articles/5061500/ASP-NET-Core-CRUD-Operations-With-Paging-Sorting-S
+ https://www.c-sharpcorner.com/article/implement-crud-operations-with-sorting-searching-and-paging-using-ef-core-in-as/

## Unit Testing
+ xUnit Test Project

## Integration Testing
+ SqlLocalDB
+ SQL Server Express LocalDB

# NET 8
+ CRUD with Blazor in .NET 8 🔥 Video & Code Inside 🚀
+ CRUD with Blazor in .NET 8 🔥 All Render Modes (SSR, Server, Wasm, Auto), Entity Framework & SQL Server
+ https://www.youtube.com/watch?v=w8imy7LT9zY
+ Table of Contents:
	+ 00:00:00 CRUD w/ Blazor in .NET 8 🔥
	+ 00:01:58 New Templates & Rendermodes Explained
	+ 00:20:41 Preparations (Entities, EF Core, SQL Server)
	+ 00:29:58 Create a Service for the CRUD Operations
	+ 00:32:36 Add Page/Component to Get all Games (SSR + StreamRendering)
	+ 00:37:52 Add Interactivity for a Button  - Create/POST Preparations
	+ 00:46:27 Create an Interactive Button Component
	+ 00:50:21 Create a Game with the new .NET 8 SSR Form
	+ 00:55:49 Use WebAssembly to Create a Game
	+ 01:16:05 Quick Look at RenderModeInteractiveAuto
	+ 01:17:45 Implement Updating & Deleting a Game

# References
+ Integration Testing with Entity Framework Core and SQL Server
+ https://www.davepaquette.com/archive/2016/11/27/integration-testing-with-entity-framework-core-and-sql-server.aspx
+ https://github.com/gtechsltn/EntityFrameworkCoreIntegrationTest
