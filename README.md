# TaxiManager
The Taxi Manager application is a .NET MVC application designed to help manage drivers and cars in a taxi company. It provides functionality for different user roles to perform various tasks related to managing drivers and cars.

## Features

- User Authentication and Authorization: The application uses ASP.NET Identity with user roles to manage user authentication and authorization.
- Repository Pattern: The application follows the repository pattern to separate data access logic from business logic.
- Entity Framework Core: The application uses Entity Framework Core as the ORM to interact with the underlying database.
- Responsive UI: The application provides a responsive user interface built with Razor views and Bootstrap for a better user experience.

## Prerequisites

- .NET Core 6.0
- SQL Server (or any other supported database) installed and configured

## Installation

1. Clone the repository:

   ```shell
   git clone https://github.com/chrissjj/TaxiManagerMVC.git
   ```
2. Open the solution in your preferred IDE.
3. Update the database connection string in the appsettings.json file with your own SQL Server connection string.
4. Apply the database migrations.

## Configuration
The application uses the following configuration settings, which can be modified in the `appsettings.json` file:
- `ConnectionString`: Specifies the connection string for the SQL Server database.

## Project Structure
- `DataAccess`: Contains the data access layer, including repositories and the database context.
- `Models`: Defines the entity models used in the application.
- `Utils`: Contains utility classes and helper functions used throughout the application.
- `Views`: Contains the Razor views for rendering the user interface.
- `Areas`: Contains the segregation for each user role and what they can do.
- `Controllers`: Contains the controllers responsible for handling user requests and performing the necessary actions.
