[Clean Architecture with .NET Core: Getting Started](https://jasontaylor.dev/clean-architecture-getting-started/)
The Presentation project represents the Presentation layer. This project is a SPA (single page app) based on Angular 8 and ASP.NET Core. This layer depends on both the Application and Infrastructure layers. Please note the dependency on Infrastructure is only to support dependency injection. Therefore Startup.cs should include the only reference to Infrastructure

[Clean Architecture with .NET and .NET Core — Overview](https://medium.com/dotnet-hub/clean-architecture-with-dotnet-and-dotnet-core-aspnetcore-overview-introduction-getting-started-ec922e53bb97)
This layer is also called as Presentation. Presentation Layer contains the UI elements (pages, components) of the application. It handles the presentation (UI, API, etc.) concerns. This layer is responsible for rendering the Graphical User Interface (GUI) to interact with the user or Json data to other systems. It is the application entry-point.

User Interface layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. This layer can be an ASP.NET Core Web API with Single Page Application (SPA like Angular, React) or it can be an ASP.NET Core MVC with Razor Views.

This layer receives HTTP Requests from users, and Presenters converts the application outputs into ViewModels that are rendered as HTTP Responses.

User Interface layer contains:

Controllers
Views
View Models
Middlewares
Filters/Attributes
Web/API Utilities


[Implementing a Clean Architecture in ASP.NET Core 6](https://thecodewrapper.com/dev/implementing-clean-architecture-in-aspnetcore-6/)
This layer essentially contains the I/O components of the system, the GUI, REST APIs, mobile applications or console shells, and anything directly related to them. It is the starting point of our application.

For this starting point solution, it contains the following:

ASP.NET Core MVC web application using Razor Components
A shared class library containing common Razor Components, such as toast notifications, modal components, Blazor Select2, DataTablesJS integration and CRUD buttons