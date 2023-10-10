[Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)
The Application project represents the Application layer and contains all business logic. This project implements CQRS (Command Query Responsibility Segregation), with each business use case represented by a single command or query. This layer is dependent on the Domain layer but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application needs to access a notification service, a new interface would be added to the Application and the implementation would be created within Infrastructure.


[Clean Architecture with .NET and .NET Core — Overview](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97)
Application Layer implements the use cases of the application based on the domain. A use case can be thought as a user interaction on the User Interface (UI). This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers.

Application layer contains the application Use Cases which orchestrate the high level business rules. By design the orchestration will depend on abstractions of external services (e.g. Repositories). The package exposes Boundaries Interfaces (in other terms Contracts or Ports or Interfaces) which are used by the User Interface.

For example, if the application need to access a email service, a new interface would be added to application and an implementation would be created within infrastructure.

Application layer contains:

Abstractions/Contracts/Interfaces
Application Services/Handlers
Commands and Queries
Exceptions
Models (DTOs)
Mappers
Validators
Behaviors
Specifications


[Implementing a Clean Architecture in ASP.NET Core 6](https://thecodewrapper.com/dev/implementing-clean-architecture-in-aspnetcore-6/)
This layer contains application-specific business logic. This contains the “what” the system should do. This includes:

Interfaces for infrastructure components such as repositories, unit-of-work and event sourcing.
Commands and Queries models and handlers
Interfaces and DTOs for cross-cutting concerns (i.e. service bus)
Authorization operations, requirements and handlers implementations
Interfaces and concrete implementations of application-specific business logic services.
Mapping profiles between domain entities and CQRS models