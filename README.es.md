[Read this document in English](README.md)

# API de la Biblioteca Municipal (Proyecto de Portfolio)

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet) ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-9.0-512BD4?style=for-the-badge) ![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)

## Resumen

Este repositorio contiene el código fuente de una API RESTful completa y robusta diseñada para gestionar una biblioteca municipal. Este proyecto está siendo desarrollado como una pieza de portfolio personal para demostrar conocimientos avanzados en el ecosistema .NET y en los principios de la arquitectura de software moderna.

Aunque está implementado como un monolito bien estructurado, está diseñado con la modularidad en mente, preparado para evolucionar hacia una arquitectura de microservicios.

## Características Principales (Arquitectura Objetivo)

* **Principios de Arquitectura Limpia:** La solución está estructurada para separar responsabilidades, asegurando que la lógica de negocio principal sea independiente de frameworks y detalles externos.
* **Diseño de API RESTful:** Una API CRUD completa con rutas lógicas y anidadas para recursos relacionados.
* **Control de Acceso Basado en Roles (RBAC):** Endpoints securizados mediante Autenticación y Autorización, con roles diferenciados (`Miembro`, `Bibliotecario`).
* **Patrón DTO:** Utilización de Data Transfer Objects para crear un contrato de API público seguro y flexible.
* **Validación Avanzada:** Implementación de validación a nivel de formato (con Atributos) y de reglas de negocio complejas.
* **Optimización de Rendimiento:** Inclusión de una estrategia de caché (Patrón Cache-Aside) para mejorar los tiempos de respuesta.
* **Entity Framework Core:** Uso de EF Core para la persistencia de datos con un enfoque Code-First.

## Pila Tecnológica (Tech Stack)

* **Framework:** .NET 9 / ASP.NET Core 9
* **Acceso a Datos:** Entity Framework Core 9
* **Base de Datos:** SQLite (elegida por su simplicidad y portabilidad en un entorno de desarrollo)
* **Arquitectura:** Monolito Modularizado (preparado para Microservicios)

## Estructura del Proyecto

El proyecto se organiza en una Solución de .NET (`.sln`) para promover la separación de responsabilidades y la escalabilidad.

```
municipal-library/
├── municipal-library.sln         # El Fichero de Solución
└── src/                          # Carpeta del código fuente
    └── MunicipalLibrary.Api/     # El proyecto de la Web API con ASP.NET Core

# (Futuros proyectos como .Web, .Core, .Tests se añadirán aquí)
```

## Hoja de Ruta (Roadmap)

Este proyecto está actualmente en desarrollo activo. El objetivo es completar todas las funcionalidades definidas para la v1.0.

### v1.0: API Principal y Funcionalidad
* **Fase 1: Capa de Datos y Persistencia**
    * [X] Instalar y configurar Entity Framework Core con SQLite.
    * [X] Definir los Modelos de Datos (`Libro`, `Autor`, `Usuario`, `Prestamo`).
    * [X] Crear la base de datos inicial mediante Migraciones de EF Core.
* **Fase 2: Lógica de Negocio y Endpoints**
    * [X] Implementar el CRUD completo para `Libros` y `Autores`.
    * [ ] Implementar la lógica y endpoints para `Préstamos`.
    * [ ] Integrar el patrón DTO para todas las comunicaciones de la API.
* **Fase 3: Calidad y Seguridad**
    * [ ] Añadir Validación a los DTOs de entrada y a la lógica de negocio.
    * [ ] Implementar Autenticación y Autorización basada en roles (`Miembro`, `Bibliotecario`).
* **Fase 4: Optimización**
    * [ ] Implementar una estrategia de Caching para las consultas de lectura.

### v2.0: Aplicación Frontend (Futuro)
* [ ] Desarrollo de una interfaz de usuario web (Blazor o Angular) para consumir esta API.

### Mejoras Futuras
* [ ] Implementar una suite de Testing (Unitario y de Integración).
* [ ] Configuración de un pipeline de CI/CD con GitHub Actions.
* [ ] "Dockerización" de la aplicación para un despliegue sencillo.

## Cómo Empezar

Instrucciones para ejecutar el proyecto en un entorno local.

1.  Clonar el repositorio:
    ```sh
    git clone https://github.com/mberral/municipal-library.git
    ```
2.  Navegar a la carpeta del repositorio:
    ```sh
    cd municipal-library
    ```
3.  Restaurar las dependencias de .NET:
    ```sh
    dotnet restore
    ```
4.  Ejecutar la API (desde la carpeta raíz):
    ```sh
    dotnet run --project src/MunicipalLibrary.Api --launch-profile https
    ```
La API estará disponible en la URL que indique la consola (ej. `https://localhost:7086`), y la interfaz de Swagger se puede acceder en `/swagger`.

## Licencia

Distribuido bajo la Licencia MIT. Ver el fichero `LICENSE` para más información.