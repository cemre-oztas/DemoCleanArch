# ASP.NET Project with Clean Architecture
This project implements clean architecture using ASP.NET.

## Project Structure

- **Core**
  - **Application**: Business logic and services.
    - **DTOs**: Data Transfer Objects for communication between layers.
    - **Features**: Specific functionalities (e.g., user registration).
    - **Repositories**: Data access management.
    - **ServiceRegistration.cs**: Dependency injection setup.
  
  - **Domain**: Core business entities.
    - **Entities**: Main entities of the application.
      - **Common**: Common base classes.
      - **Identity**: User and role entities.
      - **Basket.cs, BasketItem.cs, CompletedOrder.cs, Menu.cs, Order.cs, Product.cs**: Core entities for the application.

- **Infrastructure**
  - **Infrastructure**: Implementations for external services.
  - **Persistence**: Data access and database configurations.

- **Presentation**
  - **API**: Web API controllers for handling requests.

## Technologies

- ASP.NET Core
- Entity Framework Core
