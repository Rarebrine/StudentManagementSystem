# 🎓 Student Management System – Microservices Architecture

This is a modular Student Management System developed using microservices architecture and MVC for the UI. It is designed to manage student and course data with scalability and maintainability in mind.

---

## ✅ What's Implemented

- ✅ Created a solution: `Student Management System`
- ✅ Added core services:
  - AuthService – handles authentication (placeholder or implemented)
  - StudentService – CRUD for student data
  - CourseService – CRUD for course data
  - StudentUI – MVC frontend consuming backend APIs
- ✅ API Testing via Swagger UI
- ✅ Backend databases are MySQL
- ✅ Clean separation of concerns via microservices
- ✅ APIs follow RESTful standards

---

## 🗃️ Services Overview

| Service         | Description                        			  | Database | API Tool  |
|-----------------|-------------------------------------------------------|----------|-----------|
| AuthService     | Handles user authentication/login (JWT authentication)| MySQL    | Swagger   |
| StudentService  | CRUD operations for student data                      | MySQL    | Swagger   |
| CourseService   | CRUD operations for course data   			  | MySQL    | Swagger   |
| StudentUI       | MVC frontend for interacting with the system          | N/A      |    -      |

---

## 🧪 API Testing

All APIs are tested and documented using Swagger.

- Swagger UI is enabled for both StudentService and CourseService
- Provides built-in interface for sending requests and viewing responses

---

## 🛠️ Technologies Used

- Language: C# / ASP.NET Core 
- Frontend: MVC (StudentUI)
- Backend: RESTful Microservices
- Database: MySQL
- API Testing: Swagger
- Build Tools: .NET CLI / Visual Studio

---

## 🧱 Architecture Diagram

[StudentUI - MVC App]
	   |
	   v
+---------------------+
|  RESTful API Layer  |
+---------------------+
	| 	     |
	v 	     v
[StudentService] [CourseService]
	| 	       |
	v 	       v
   [MySQL DB]      [MySQL DB]

---

## 🚀 How to Run Locally

1. Clone the project:
   ```bash
   git clone https://github.com/your-repo/student-management-system

2. Open solution StudentManagement System in Visual Studio.

3. Configure your MySQL connection strings in appsettings.json for each service.

4. Run each service individually:
	- StudentService
	- CourseService
	- StudentUI (set this as startup project)

5. Access Swagger at: http://localhost:PORT/swagger for each service

## 🔧 Future Work
- Add CI/CD Pipeline using Jenkins
- Add Docker and Docker Compose for containerization
- Implement AuthService with JWT authentication
- Create a service for managing Enrollments

## 👨‍💻 Group Members
- Abdul Rafay - 2380220
- Sibtain Ahmed - 2380252
- Hashir Masood - 2380243








