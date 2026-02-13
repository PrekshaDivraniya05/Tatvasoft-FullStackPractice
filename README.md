# 🚀 Full Stack Practice Project

A full-stack Customer–Order Management System built using **Angular (Frontend)** and **ASP.NET Core Web API (Backend)** with **PostgreSQL database integration**.

This project demonstrates real-world full-stack development concepts including RESTful API design, Entity Framework Core with PostgreSQL, Angular state management using RxJS, and proper layered architecture.

---

## 📌 Project Overview

This application allows users to:

- Manage Customers (Create, Update, Delete, View)
- Manage Orders linked to Customers
- Handle relational data using Foreign Keys
- Implement pagination
- Use clean architecture principles
- Integrate Angular frontend with .NET backend via CORS

---

## 🏗️ Architecture

Angular (UI Layer)
↓
Angular Services (HTTP + RxJS)
↓
ASP.NET Core Controllers
↓
Service Layer
↓
Repository Layer
↓
Entity Framework Core
↓
PostgreSQL Database


---

## 🔹 Backend Architecture

The backend follows clean layered architecture:

- Controllers
- Services
- Repositories
- DTOs (Data Transfer Objects)
- Entities
- DbContext
- Pagination Support

### Key Backend Concepts Used

- Repository Pattern
- DTO mapping
- Dependency Injection
- EF Core Relationships
- PostgreSQL Integration via Npgsql
- CORS Configuration
- Swagger Documentation
- UTC DateTime handling for `timestamp with time zone`

---

## 🔹 Frontend Architecture

The frontend is built using Angular standalone components and follows modular structure.

### Concepts Used

- Angular Standalone Components
- Angular Routing
- Template-driven Forms
- RxJS Observables
- HTTP Client
- Lifecycle Hooks (`OnInit`, `OnDestroy`)
- Reactive UI updates using `pipe()` and `tap()`

---

# 🛠️ Tech Stack

## 🔹 Backend
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Npgsql
- Swagger

## 🔹 Frontend
- Angular
- RxJS
- Bootstrap
- Angular Router
- FormsModule

---

# ✨ Features

## 👤 Customer Management

- Create new customers
- Update existing customers
- Delete customers
- View paginated customer list
- Display total order amount per customer

## 📦 Order Management

- Create orders for a specific customer
- Delete orders
- View orders by customer
- Enforced Foreign Key constraints
- UTC-safe DateTime storage

---

# 🔥 Technical Highlights

- Clean separation of concerns (Controller → Service → Repository)
- DTO usage instead of exposing EF entities
- Foreign key validation before inserting orders
- RESTful API design
- Pagination using query parameters
- CORS configuration for Angular integration
- PostgreSQL `timestamp with time zone` compatibility
- RxJS operators (`pipe`, `tap`, `subscribe`) for reactive UI updates
- Proper lifecycle hook usage

---

# API ENDPOINTS OVERVIEW
# Customers

GET /api/customers
GET /api/customers/{id}
POST /api/customers
PUT /api/customers/{id}
DELETE /api/customers/{id}

# Orders

GET /api/orders
GET /api/orders/{id}
GET /api/orders/customer/{customerId}
POST /api/orders
DELETE /api/orders/{id}

