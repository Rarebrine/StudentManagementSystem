# StudentService Microservice

## Overview
Provides CRUD operations for students via RESTful API.

## Prerequisites
- .NET 8 SDK
- MySQL server running (default port 3306)

## Setup
1. Update `appsettings.json` with your MySQL credentials.
2. Open terminal in `StudentService/`:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   Run the service:

dotnet run

Open Swagger UI at https://localhost:5001/swagger to test endpoints.