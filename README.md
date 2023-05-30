[![CI/CD](https://github.com/ThomasBernard03/FoodiesAPI/actions/workflows/main.yml/badge.svg?branch=main)](https://github.com/ThomasBernard03/FoodiesAPI/actions/workflows/main.yml)

# FoodiesAPI

## Introduction

This API allows you to manage a recipe book, creating, modifying and deleting recipes, ingredients and preparation steps.


## Development

### Database connection

In this project, we use Entity Framework Core, so you can use different databases such as SQLServer or PostgresSQL.

To connect to the database, you need to apply several modifications to the project.
First, create an appsettings.json file at the root of the API project :

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "SqlServer": "Server=tcp:localhost,1433;Initial Catalog=Foodies;Persist Security Info=False;User ID=sa;Password=your_password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;",
    "PgServer": "Host=localhost,5432;Database=Foodies;Username=postgres;Password=your_password"
  }
}

```


### Migrations

Modify the FoodiesContextFactory file in the DataAccess project with the connection string to your database :
```csharp
using Microsoft.EntityFrameworkCore.Design;

namespace Foodies.DataAccess;

internal class FoodiesContextFactory : IDesignTimeDbContextFactory<FoodiesDbContext>
{
    public FoodiesDbContext CreateDbContext(string[] args)
    {
        //const string connection = "Server=tcp:localhost,1433;Initial Catalog=Foodies;Persist Security Info=False;User ID=sa;Password=your_password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        const string connection = "Host=localhost,5432;Database=Foodies;Username=postgres;Password=your_password";

        return new FoodiesDbContext(connection);
    }
}
```

Install dotnet ef tool :
```shell
dotnet tool install --global dotnet-ef
```

Apply existing migrations :
```shell
dotnet ef database update
```


Add a new migration :
```shell
dotnet ef migrations add YourMigrationName
dotnet ef database update
```