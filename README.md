**[EGY-Task]**

## Description
A small CRUD backend application using Minimal API, CQRS Mediator pattern, and Fluent Validation, integrated with an Angular frontend.

### Key Features

- **CQRS with Mediator Source Generators Design Pattern**: Separates command and query responsibilities, enhancing code clarity and maintainability.
- **Minimal API**: Utilizes Minimal API for efficient routing and lightweight HTTP request handling.
- **Validation**:
  - **Automatic Validation**: Implements automatic validation using the ASP.NET validation pipeline, ensuring models are validated before a controller action is invoked.
  - **Fluent Validation**: Integrates Fluent Validation into the pipeline, providing a flexible and extensible way to validate models.
  - **Phone Number Validation**: Utilizes `libphonenumber` for accurate phone number parsing, validation, and formatting.
- **ASP.NET Core Identity**: Provides secure user authentication and authorization handling.
- **Generic Implementation for Pagination**: Adds generic pagination support for handling large datasets across various endpoints.

### Endpoints

- **Login**: Handles user authentication and issues tokens upon successful login.
- **Register**: Registers new users with necessary details and role assignments.
- **Add Client**: Adds a new client to the system with all required validations.
- **Get Clients + Pagination**: Retrieves a paginated list of clients for efficient data handling.
- **Get Calls of Client**: Retrieves a list of calls associated with a specific client.
- **Update Client**: Updates client details while applying necessary validations.

## Technologies Used

- **ASP.NET Core Web API**
- **CQRS with Mediator**
- **Fluent Validation**
- **ASP.NET Core Identity**
- **Entity Framework Core**
- **Minimal API**
