[Leer este documento en Español](README.es.md)

# Municipal Library API (Portfolio Project)

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet) ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-9.0-512BD4?style=for-the-badge) ![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)

## Overview

This repository contains the source code for a comprehensive and robust RESTful API designed to manage a municipal library. This project is being developed as a personal portfolio piece to showcase advanced skills in the .NET ecosystem and modern software architecture principles.

While being implemented as a well-structured monolith, it is designed with modularity in mind, ready to evolve into a microservices architecture.

## Key Features (Target Architecture)

* **Clean Architecture Principles:** The solution is structured to separate concerns, ensuring the core business logic is independent of frameworks and external details.
* **RESTful API Design:** A complete CRUD API with logical, nested routes for related resources.
* **Role-Based Access Control (RBAC):** Secure endpoints using Authentication and Authorization, with distinct roles (`Member`, `Librarian`).
* **DTO Pattern:** Utilizes Data Transfer Objects to create a secure and flexible public-facing API contract.
* **Advanced Validation:** Implements both data annotation-based validation and complex business rule validation.
* **Performance Optimization:** Includes a caching strategy (Cache-Aside Pattern) to improve response times.
* **Entity Framework Core:** Leverages EF Core for data persistence with a code-first approach.

## Tech Stack

* **Framework:** .NET 9 / ASP.NET Core 9
* **Data Access:** Entity Framework Core 9
* **Database:** SQLite (chosen for its simplicity and portability in a development environment)
* **Architecture:** Modular Monolith (designed for future transition to Microservices)

## Project Structure

The project is organized into a .NET Solution (`.sln`) to promote separation of concerns and scalability.

```
municipal-library/
├── municipal-library.sln         # The Solution File
└── src/                          # Source code folder
    └── MunicipalLibrary.Api/     # The ASP.NET Core Web API project

# (Future projects like .Web, .Core, .Tests will be added here)
```

## Roadmap

This project is currently under active development. The goal is to complete all features defined for v1.0.

### v1.0: Core API & Functionality
* **Phase 1: Data Layer & Persistence**
    * [X] Install and configure Entity Framework Core with SQLite.
    * [X] Define Data Models (`Book`, `Author`, `User`, `Loan`).
    * [ ] Create initial database via EF Core Migrations.
* **Phase 2: Business Logic & API Endpoints**
    * [ ] Implement full CRUD for `Books` and `Authors`.
    * [ ] Implement core logic and endpoints for `Loans`.
    * [ ] Integrate the DTO pattern for all API communications.
* **Phase 3: Quality & Security**
    * [ ] Add validation to all input DTOs and business logic.
    * [ ] Implement Authentication and Role-Based Authorization.
* **Phase 4: Optimization**
    * [ ] Implement caching strategy for read-heavy endpoints.

### v2.0: Frontend Application (Future)
* [ ] Develop a web user interface (Blazor or Angular) to consume this API.

### Future Enhancements
* [ ] Implement a testing suite (Unit & Integration).
* [ ] Set up a CI/CD pipeline with GitHub Actions.
* [ ] "Dockerize" the application for containerized deployment.

## Getting Started

To get a local copy up and running, follow these simple steps.

1.  Clone the repo:
    ```sh
    git clone https://github.com/mberral/municipal-library.git
    ```
2.  Navigate to the repository folder:
    ```sh
    cd municipal-library
    ```
3.  Restore .NET dependencies:
    ```sh
    dotnet restore
    ```
4.  Run the API project (from the root folder):
    ```sh
    dotnet run --project src/MunicipalLibrary.Api --launch-profile https
    ```
The API will be available at the URL shown in the console (e.g., `https://localhost:7086`), and the Swagger UI can be accessed at `/swagger`.

## License

Distributed under the MIT License. See `LICENSE` for more information.