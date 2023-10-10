[Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)
The Domain project represents the Domain layer and contains enterprise or domain logic and includes entities, enums, exceptions, interfaces, types and logic specific to the domain layer. This layer has no dependencies on anything external.

[Clean Architecture with .NET and .NET Core — Overview](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97)
Domain Layer implements the core, use-case independent business logic of the domain/system. By design, this layer is highly abstracted and stable. This layer contains a considerable amount of domain entities and should not depend on external libraries and frameworks. Ideally it should be loosely coupled even to the .NET Framework.

Domain project is core and backbone project. It is the heart and center project of the Clean Architecture design. All other projects should be depended on the Domain project.

This package contains the high level modules which describe the Domain via Aggregate Roots, Entities and Value Objects.

Domain layer contains:

Entities
Aggregates
Value Objects
Domain Events
Enums
Constants


[Implementing a Clean Architecture in ASP.NET Core 6](https://thecodewrapper.com/dev/implementing-clean-architecture-in-aspnetcore-6/)
This layer contains application-independent business logic. This is the part of the business logic which would be the same even if we weren’t building a software. It is a formulation of the core business rules.

The organization of this project follows Domain-Driven design patterns, although this is a matter of preference and can be handled any way you see fit. This includes:

Aggregates, entities, value objects, custom domain exceptions, and interfaces for domain services.
Interfaces for domain-driven design concepts (i.e. IAggregateRoot, IDomainEvent, IEntity).
Base implementations of aggregate root and domain event. Also contains specific domain events pertaining to the business processes.