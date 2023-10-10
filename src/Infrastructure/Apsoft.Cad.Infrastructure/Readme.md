[Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)
The Infrastructure project represents the Infrastructure layer and contains classes for accessing external resources such as file systems, web services, SMTP, and so on. These classes should be based on interfaces defined within the Application layer.

[Clean Architecture with .NET and .NET Core — Overview](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97)
This layer is responsible to implement the Contracts (Interfaces/Adapters) defined within the application layer to the Secondary Actors. Infrastructure Layer supports other layer by implementing the abstractions and integrations to 3rd-party library and systems.

Infrastructure layer contains most of your application’s dependencies on external resources such as file systems, web services, third party APIs, and so on. The implementation of services should be based on interfaces defined within the application layer.

If you have a very large project with many dependencies, it may make sense to have multiple Infrastructure projects, but for most projects one Infrastructure project with folders works fine.

Infrastructure.Persistence
- Infrastructure.Persistence.MySQL
- Infrastructure.Persistence.MongoDB
Infrastructure.Identity
Infrastructure layer contains:

Identity Services
File Storage Services
Queue Storage Services
Message Bus Services
Payment Services
Third-party Services
Notifications
- Email Service
- Sms Service
Persistence Layer
This layer handles database concerns and other data access operations. By design the infrastructure depends on Application layer. This project contains implementations of the interfaces (e.g. Repositories) that defined in the Application project.

For instance an SQL Server Database is a secondary actor which is affected by the application use cases, all the implementation and dependencies required to consume the SQL Server is created on infrastructure (persistence) layer.

For example, if you wanted to implement the Repository pattern you would do so by adding an interface within Application layer and adding the implementation within Persistence (Infrastructure) layer.

Persistence layer contains:

Data Context
Repositories
Data Seeding
Data Migrations
Caching (Distributed, In-Memory)

[Implementing a Clean Architecture in ASP.NET Core 6](https://thecodewrapper.com/dev/implementing-clean-architecture-in-aspnetcore-6/)
This layer contains details, concrete implementations for repositories, unit-of-work, event store, service bus implementations etc. This contains the “how” the system should do what is supposed to do. The decoupling between the application layer and the infrastructure layer is what allows solution structures like this one to change and/or add specific implementations as the project requirements change.

In overview, this layer contains:

Generic and specific repositories implementations
EF DbContexts, data models and migrations
Event sourcing persistence and services implementations
Implementations for cross-cutting concerns (i.e, application configuration service, localization service etc.)
Data entity auditing implementation
This consists of 3 projects in the solution under the Infrastructure folder, the Auditing, Data and Shared projects.

The Auditing project consists of various extensions methods for DbContext, primarily related to SaveChanges. It is responsible for generating auditing records for each tracked entity’s changes.

The Data project contains domain and generic (CRUD and event-sourcing) repository implementations, DbContexts, EF Core migrations, entity type configurations (if any), event store implementation (including snapshots), data entity to domain object mappings, and persistence related services (i.e. a database initializer service).

The Resources project contains localized shared resources and resource keys, along with localization services implementations.

The Shared project contains service implementations for cross-cutting concerns such as user management and authentication, file storage, service bus, localization, application configuration and a password generator.

To install ef-cli
dotnet tool install --global dotnet-ef

To create initial migrations:
dotnet ef migrations add InitialCreate

To create db:
dotnet ef database update