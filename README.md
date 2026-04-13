# 🚀 TaskFlow Pro – Enterprise Task Management System

TaskFlow Pro is a **production-grade backend system built with .NET 8**, following **Clean Architecture principles** for scalability, maintainability, and separation of concerns.

---

## 🧠 Overview

TaskFlow Pro enables efficient management of:

* Projects
* Tasks
* Users & Roles
* Comments & Activity Logs

It simulates a **real-world enterprise task management system** similar to Jira or Trello.

---

## 🏗️ Architecture

```bash
TaskFlowPro/
│
├── TaskFlowPro.API            # Controllers & Middleware
├── TaskFlowPro.Application    # Business Logic
├── TaskFlowPro.Domain         # Entities & Core Rules
├── TaskFlowPro.Infrastructure # Database & Services
```

---

## ⚙️ Tech Stack

* ASP.NET Core (.NET 8)
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt Password Hashing
* Docker
* Swagger (OpenAPI)

---

## ✨ Features

* 🔐 JWT Authentication & Authorization
* 👥 Role-Based Access Control (RBAC)
* 📁 Project Management APIs
* ✅ Task Assignment & Tracking
* 💬 Comment System
* 📊 Activity Logging
* 🐳 Docker Support
* 📄 Swagger API Documentation

---

## 🚀 Getting Started

### 🔧 Prerequisites

```bash
.NET 8 SDK
Docker Desktop (optional)
dotnet tool install --global dotnet-ef
```

---

## ▶️ Run the Project

### 🐳 Using Docker (Recommended)

```bash
docker-compose up -d --build
```

Swagger:
http://localhost:5000/swagger

---

### 💻 Run Locally

```bash
dotnet restore
```

```bash
dotnet ef migrations add InitialMigration \
--project TaskFlowPro.Infrastructure \
--startup-project TaskFlowPro.API \
--output-dir Persistence/Migrations
```

```bash
dotnet ef database update \
--project TaskFlowPro.Infrastructure \
--startup-project TaskFlowPro.API
```

```bash
cd TaskFlowPro.API
dotnet run
```

Swagger:
https://localhost:7154/swagger

---

## 🗄️ Database Schema Diagram

<img width="2002" height="2059" alt="mermaid-diagram" src="https://github.com/user-attachments/assets/22cade40-5a84-4c61-b25f-f1dd3516a5f7" />


---

## 📌 Key Relationships

* A **User** can own multiple **Projects**
* A **Project** contains multiple **Tasks**
* A **Task** is assigned to a **User**
* A **Task** can have multiple **Comments**
* Users are mapped to roles via **RoleUser**

---

## 🔐 Authentication Flow

1. User sends login request → `/api/auth/login`
2. API validates credentials using BCrypt
3. JWT token is generated (UserId, Email, Roles)
4. Client receives token
5. Token is used in header:

   ```
   Authorization: Bearer <token>
   ```
6. Middleware validates token → access granted or `401 Unauthorized`

---

## 📬 API Testing

* Import: `TaskFlowPro_Postman_Collection.json`
* Add Bearer Token
* Test endpoints:

  * `/api/auth/login`
  * `/api/project`
  * `/api/task`

---

## 📁 Folder Structure

```bash
TaskFlowPro/
│
├── API/
├── Application/
├── Domain/
├── Infrastructure/
```

---

## 🧪 Future Improvements

* Unit & Integration Testing
* Redis Caching
* Notifications System
* Frontend Integration

---



## 👨‍💻 Author

Aashutosh Rana
