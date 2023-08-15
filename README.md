# My-Task-Manager

A Task Manager web application built with Blazor WebAssembly, utilizing SQL Server as the backend database and Entity Framework for data management. This app allows users to efficiently manage their tasks, track progress, and maintain productivity.


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites
```
.Net7 SDK

SQL Server
```

### Installing

A step by step series of examples that tell you how to get a development env running

Clone the repository:
```
git clone https://github.com/ram410/My-Task-Manager.git
```

Navigate to project Directory:

```
cd My-Task-Manager
```

Restore dependencies:

```
cd My-Task-Manager
```

Restore dependencies:
```
dotnet restore
```
Update the connection string in `appsettings.json` to point to your SQL Server.

Apply migrations to create the database:
```
dotnet ef database update
```
Rub application:
```
dotnet run
```


## Built With

* [.Net7](https://learn.microsoft.com/en-us/dotnet/) 
* [c#](https://learn.microsoft.com/en-us/dotnet/csharp/)
* HTML
* CSS


## Authors

* **Amo Richard Mante**
