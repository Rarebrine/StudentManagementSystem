# CourseService

## Overview
Microservice for managing courses.  
Exposes CRUD endpoints at `/api/courses` with Swagger UI.

## Requirements
- .NET 8.0 SDK
- MySQL 8.x
- `dotnet-ef` tool (`dotnet tool install --global dotnet-ef`)

## Setup

1. Update `appsettings.json` with your MySQL credentials.
2. Create the database:
   ```bash
   mysql -u root -p
   CREATE DATABASE CourseDb;
   cd CourseService
   dotnet ef migrations add InitialCreate
   dotnet ef database update

   dotnet run```
   
3. https://localhost:5001/swagger

