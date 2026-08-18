# Curriculum Vitae Web

Personal portfolio and curriculum web application developed to showcase my professional experience, projects, certifications, and technical skills.

## About the Project

The project was initially proposed as a simple static webpage. However, I decided to expand it into a dynamic web application with database integration, a structured architecture, and an interactive frontend.

Professional experiences, projects, and certifications are stored in a SQL Server database, allowing the content to be updated without modifying the frontend code.

## Technologies

### Backend
- C#
- ASP.NET Core MVC
- Razor / CSHTML
- Dapper
- SQL Server

### Frontend
- HTML5
- JavaScript
- Tailwind CSS

### Architecture
- Clean Architecture
- SOLID Principles
- Dependency Injection
- Repository Pattern
- Service Layer
- DTOs

## Project Structure

The application is divided into three main modules:

### Core

Contains the main application logic and contracts.

- Domain Entities
- DTOs
- Service Contracts
- Services
- Repository Contracts

The Core layer is independent from Infrastructure and UI, keeping the application logic separated from external technologies.

### Infrastructure

Responsible for external concerns and database communication.

- Database connection management
- Repository implementations
- Dapper integration
- SQL Server access

Repositories are responsible for executing SQL queries and retrieving data from the database.

### UI

Responsible for the presentation layer using ASP.NET Core MVC.

- Controllers
- Razor / CSHTML Views
- JavaScript
- Tailwind CSS
- Static assets

The UI retrieves data through the application services and displays it using strongly typed Razor views.

## Purpose

This project serves as my personal online curriculum while also demonstrating my practical knowledge of software development.

It allowed me to apply concepts and technologies that I use in my professional development environment, especially C#, .NET, SQL Server, database integration, software architecture, and frontend development.

Instead of creating only a static portfolio, I chose to develop a complete dynamic web application where the content can be updated through the database.

## Deployment

The application and database are hosted through Monster ASP.NET, allowing the project to run in a real production environment.
https://thiagowb.runasp.net/

## Author

**Thiago Wurster Balbinot**

Full-Stack Developer focused on .NET, C#, backend development, databases, infrastructure, and software architecture.
