# EventHubMVC

EventHubMVC is a web application developed with ASP.NET Core MVC for managing events, venues, organizers, and categories.  
The project was created as part of the Web Application Design course and follows a layered architecture using Services and Repository Pattern.

---

# Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Bootstrap 5
- Razor Views

---

# Main Features

## Event Management
- Create events
- Edit events
- Delete events
- View event details
- Search events

## Category Management
- CRUD operations for categories

## Venue Management
- CRUD operations for venues

## Organizer Management
- CRUD operations for organizers

## Authentication & Authorization
- User registration
- User login/logout
- Role-based authorization
- Admin and User roles

## Frontend
- Responsive design using Bootstrap
- Custom cards and layouts
- Improved CRUD pages
- Custom Login/Register pages

---

# Project Architecture

The application follows a layered architecture:

```text
View
↓
Controller
↓
Service
↓
Repository
↓
Entity Framework Core
↓
SQL Server
```

---

# Entity Relationships

- One Category → Many Events
- One Venue → Many Events
- One Organizer → Many Events
- One Event → Many Reservations
- One Attendee → Many Reservations

---

# Repository Pattern

Repositories are responsible for database access.

Examples:
- EventRepository
- CategoryRepository
- VenueRepository
- OrganizerRepository

---

# Service Layer

Services contain the business logic of the application.

Examples:
- EventService
- CategoryService
- VenueService
- OrganizerService

---

# Authentication System

The application uses ASP.NET Identity for:
- Authentication
- User management
- Role management
- Authorization

Roles implemented:
- Admin
- User

Only administrators can:
- Create
- Edit
- Delete

Regular users can:
- View information
- Search events

---

# Database

Entity Framework Core Code First approach was used.

Migration commands:

```powershell
Add-Migration InitialCreate
Update-Database
```

---

# Installation

## 1. Clone repository

```bash
git clone https://github.com/i22agpoa/EventHubMvc
```

## 2. Open the project

Open the solution in Visual Studio.

## 3. Configure database connection

Update the connection string in:

```json
appsettings.json
```

## 4. Apply migrations

Open Package Manager Console:

```powershell
Update-Database
```

## 5. Run the application

Press:

```text
Ctrl + F5
```

or run:

```bash
dotnet run
```

---

# Default Admin User

Example admin account:

```text
Email: admin@eventhub.com
Password: admin
```

---

# Learning Objectives

This project allowed practicing:
- ASP.NET Core MVC
- Entity Framework Core
- Repository Pattern
- Service Layer
- Razor Views
- Authentication & Authorization
- Bootstrap frontend development
- Layered architecture
- CRUD operations

---

# Author

Adrián Aguilar Porcel

Web Application Design Project – 2026
