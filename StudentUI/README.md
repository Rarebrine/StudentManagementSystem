# StudentUI

ASP.NET Core MVC frontend for StudentService & CourseService.

## Prerequisites

- .NET 8.0 SDK
- Running StudentService (https://localhost:5001)
- Running CourseService  (https://localhost:5002)

## Configuration

1. Open **appsettings.json** and adjust:
   ```json
   "ServiceUrls": {
     "StudentService": "https://localhost:5001/",
     "CourseService": "https://localhost:5002/"
   }
Ensure both services are up and their Swagger UIs return JSON.

Run
bash
Copy
Edit
cd StudentUI
dotnet run
Browse to https://localhost:5000/ (or shown port) to manage students & courses.

yaml
Copy
Edit

---