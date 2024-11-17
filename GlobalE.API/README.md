# Timer API

## Overview

The Timer API provides endpoints to manage timers. It supports various repository implementations, including in-memory storage, MongoDB, and MSSQL. This README provides instructions for setting up and running the project, as well as details on how to use the API.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [MongoDB](https://www.mongodb.com/try/download/community) (if using MongoDB repository)
- [MSSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (if using MSSQL repository) // NotImplemented

## Configuration

### appsettings.json

Configure the application by modifying the `appsettings.json` file:

```json
{
  "RepositorySettings": {
    "RepositoryType": "Mongo" // Options: "Mongo", "Mssql", "InMemory"
  },
  "MongoSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "TimerDb"
  },
  "MssqlSettings": {
    "ConnectionString": "Server=yourserver;Database=yourdb;User Id=youruser;Password=yourpassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
