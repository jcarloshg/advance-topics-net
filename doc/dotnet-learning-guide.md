# .NET Developer Learning Guide

## Master .NET with Structured, Prioritized Topics

**Target Framework:** .NET 8+ | **Focus:** Web API & Full-Stack Development  
**For:** Beginner → Intermediate → Senior Developer / Architect

---

## Table of Contents

1. [C# Language Fundamentals](#1-c-language-fundamentals)
2. [.NET Runtime & Framework](#2-net-runtime--framework)
3. [ASP.NET Core](#3-aspnet-core)
4. [Data Access](#4-data-access)
5. [Architecture & Design Patterns](#5-architecture--design-patterns)
6. [Testing](#6-testing)
7. [Performance & Optimization](#7-performance--optimization)
8. [Cloud & DevOps](#8-cloud--devops)
9. [Security](#9-security)
10. [Modern .NET 8/9 Features](#10-modern-net-89-features)

---

# 1. C# LANGUAGE FUNDAMENTALS

## 1.1 Core Syntax & Data Types

| Aspect              | Details                                                                                                                                        |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | C# Syntax Basics & Data Types                                                                                                                  |
| **Description**     | Foundation of C# programming: variables, primitive types, operators, control flow, and type system. Essential for all .NET development.        |
| **Key Concepts**    | Value types vs Reference types • Nullable types & null-coalescing operators • Type inference (var, dynamic) • Implicitly typed local variables |
| **Skill Level**     | Beginner                                                                                                                                       |
| **Priority**        | **MUST-KNOW**                                                                                                                                  |
| **Resources**       | • C# Keywords: `var`, `const`, `readonly` • Value types: struct, enum, bool, int, double, decimal • Reference types: class, string, array      |
| **Interview Focus** | Explain value vs reference types • Stack vs Heap memory • When to use `decimal` vs `double`                                                    |

## 1.2 Object-Oriented Programming (OOP)

| Aspect              | Details                                                                                                                                                                                                     |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | OOP Core Concepts                                                                                                                                                                                           |
| **Description**     | Pillars of OOP: encapsulation, inheritance, polymorphism, abstraction. Critical for designing scalable, maintainable applications.                                                                          |
| **Key Concepts**    | Classes & Objects • Inheritance & Method Overriding • Polymorphism (method & operator overloading) • Encapsulation (access modifiers: public, private, protected, internal) • Interfaces & Abstract Classes |
| **Skill Level**     | Beginner → Intermediate                                                                                                                                                                                     |
| **Priority**        | **MUST-KNOW**                                                                                                                                                                                               |
| **Deep Dive**       | • `virtual` vs `abstract` vs `sealed` • Method resolution order • Constructor chaining (`base`, `this`) • `partial` classes                                                                                 |
| **Interview Focus** | Design a class hierarchy • Implement interface segregation • Explain sealed classes • Virtual method dispatch                                                                                               |

## 1.3 Advanced Language Features

| Aspect              | Details                                                                                                                                                                                                           |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | LINQ, Delegates, Events, Generics                                                                                                                                                                                 |
| **Description**     | Advanced features enabling functional programming patterns, type-safe abstractions, and event-driven architecture. Essential for modern C# code.                                                                  |
| **Key Concepts**    | LINQ query syntax vs method syntax • Delegates & Lambda expressions • Events & EventHandler pattern • Generics: constraints, covariance/contravariance • Tuples & Pattern Matching                                |
| **Skill Level**     | Intermediate                                                                                                                                                                                                      |
| **Priority**        | **MUST-KNOW**                                                                                                                                                                                                     |
| **Detailed Topics** | LINQ Providers (IEnumerable, IQueryable) • Lazy evaluation • Deferred execution • `Action<T>`, `Func<T>`, `Predicate<T>` • Where constraints (class, struct, new(), T:U) • Recursive patterns • Property patterns |
| **Common Mistakes** | Using `.ToList()` prematurely in LINQ chains • Modifying collection while iterating • Not understanding deferred execution timing                                                                                 |
| **Interview Focus** | Explain LINQ provider difference (LINQ-to-Objects vs LINQ-to-SQL) • Write complex query with nested predicates • Pattern matching use cases                                                                       |

## 1.4 Async/Await & Threading

| Aspect              | Details                                                                                                                                                                                           |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | Asynchronous Programming                                                                                                                                                                          |
| **Description**     | Non-blocking, scalable code execution. Essential for I/O-bound operations (web requests, database queries). Modern .NET requires deep async understanding.                                        |
| **Key Concepts**    | `async`/`await` keywords • `Task` vs `Task<T>` vs `ValueTask` • Synchronization Contexts • Cancellation tokens (`CancellationToken`) • `ConfigureAwait(false)` • Exception handling in async code |
| **Skill Level**     | Intermediate → Advanced                                                                                                                                                                           |
| **Priority**        | **MUST-KNOW**                                                                                                                                                                                     |
| **Common Pitfalls** | • Async void (except event handlers) • Not awaiting async methods • Blocking on async code (`.Result`, `.Wait()`) • Not using `ConfigureAwait(false)` in libraries • Ignoring `CancellationToken` |
| **Best Practices**  | Always use `async`/`await` for I/O • Use `ConfigureAwait(false)` in libraries • Properly implement cancellation • Understand Thread Pool scheduling                                               |
| **Interview Focus** | Explain the threading model • Design async API • Handle cancellation properly • Optimize Task allocation                                                                                          |

## 1.5 Memory & Resource Management

| Aspect              | Details                                                                                                                                          |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**           | Memory Management & Disposal Patterns                                                                                                            |
| **Description**     | Understand heap vs stack, garbage collection, and proper resource cleanup. Critical for performance and preventing memory leaks.                 |
| **Key Concepts**    | Garbage Collector (Gen 0, 1, 2) • `IDisposable` & Finalizers • `using` statement & `IAsyncDisposable` • Boxing/Unboxing • Weak references        |
| **Skill Level**     | Intermediate → Advanced                                                                                                                          |
| **Priority**        | **MUST-KNOW**                                                                                                                                    |
| **Deep Dive**       | • Disposable pattern (IDisposable vs IAsyncDisposable) • Finalizer chains • `GC.Collect()` dangers • Pinned objects • Memory pressure monitoring |
| **Modern Approach** | Use `using` declarations (C# 8+) over `using` blocks • Implement `IAsyncDisposable` for async cleanup                                            |
| **Interview Focus** | When to use IDisposable • Memory leak in managed code • GC collection behavior • Finalizer gotchas                                               |

---

# 2. .NET RUNTIME & FRAMEWORK

## 2.1 Common Language Runtime (CLR)

| Aspect              | Details                                                                                                                                             |
| ------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | CLR Architecture & Execution Model                                                                                                                  |
| **Description**     | Understand how .NET code runs: from IL (Intermediate Language) to native code via JIT compilation. Foundation for debugging and optimization.       |
| **Key Concepts**    | JIT (Just-In-Time) Compilation • IL (MSIL) disassembly • AppDomains (replaced by AssemblyLoadContext in .NET Core) • Assembly loading • Type system |
| **Skill Level**     | Intermediate                                                                                                                                        |
| **Priority**        | **SHOULD-KNOW**                                                                                                                                     |
| **Tools**           | • ILSpy or dotPeek for IL analysis • JIT compiler behavior • Tiered compilation (.NET 5+)                                                           |
| **Interview Focus** | Explain JIT compilation process • IL vs native code • Assembly versioning • Type unification                                                        |

## 2.2 Assemblies & Versioning

| Aspect                   | Details                                                                                                                                                 |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | Assembly Structure, Versioning, & Loading                                                                                                               |
| **Description**          | Assemblies are the deployment units in .NET. Understanding versioning, binding, and loading is crucial for building robust applications.                |
| **Key Concepts**         | Assembly structure (manifest, metadata, IL, resources) • Strong naming • Assembly versioning strategies • Binding redirects • Assembly loading contexts |
| **Skill Level**          | Intermediate                                                                                                                                            |
| **Priority**             | **SHOULD-KNOW**                                                                                                                                         |
| **Semantic Versioning**  | Major.Minor.Patch-PreRelease+Build (e.g., 1.2.3-beta.1+20250225)                                                                                        |
| **Nuget Best Practices** | • Semantic versioning • Prerelease versions for unstable • Match assembly version to package version                                                    |
| **Interview Focus**      | Assembly loading order • Version conflicts • Breaking changes • Assembly binding redirection                                                            |

## 2.3 Type System & Reflection

| Aspect               | Details                                                                                                                                  |
| -------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**            | Reflection, Type Inspection, & Metadata                                                                                                  |
| **Description**      | Inspect and manipulate types at runtime. Powers serialization, dependency injection, ORM frameworks, and testing.                        |
| **Key Concepts**     | `Type` class • `MethodInfo`, `PropertyInfo`, `FieldInfo` • `Activator.CreateInstance()` • Attribute inspection • Generic type reflection |
| **Skill Level**      | Intermediate → Advanced                                                                                                                  |
| **Priority**         | **SHOULD-KNOW**                                                                                                                          |
| **Performance Note** | Reflection is slower; cache `Type` objects and use `Expression<T>` for performance-critical paths                                        |
| **Common Use Cases** | Dependency injection • Serialization • Unit test discovery • ORM mapping • Dynamic proxy generation                                      |
| **Interview Focus**  | Explain reflection overhead • Design efficient reflection caching • Generic type constraints reflection                                  |

## 2.4 Dependency Injection (DI)

| Aspect              | Details                                                                                                                         |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | DI Container & Lifetime Management                                                                                              |
| **Description**     | Built-in DI container since .NET Core. Essential for loose coupling, testability, and modern application architecture.          |
| **Key Concepts**    | Service registration (AddSingleton, AddScoped, AddTransient) • IServiceProvider • Service factories • Decorator pattern with DI |
| **Skill Level**     | Intermediate                                                                                                                    |
| **Priority**        | **MUST-KNOW**                                                                                                                   |
| **Lifetime Scopes** | • Singleton: One instance per application • Scoped: One per HTTP request (web) or scope • Transient: New instance every time    |
| **Common Mistakes** | • Singleton holding scoped dependency (captive dependency) • Not disposing scoped services • Circular dependencies              |
| **Best Practices**  | • Register interfaces, not implementations • Use keyed services for multiple implementations • Validate container on startup    |
| **Interview Focus** | Design DI container usage • Service lifetime strategy • Solve dependency resolution issues                                      |

---

# 3. ASP.NET CORE

## 3.1 Web API Fundamentals

| Aspect                  | Details                                                                                                                                          |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**               | Building RESTful Web APIs                                                                                                                        |
| **Description**         | RESTful principles, HTTP semantics, and ASP.NET Core routing. Fundamental for modern API development.                                            |
| **Key Concepts**        | HTTP methods (GET, POST, PUT, DELETE, PATCH) • Status codes (2xx, 3xx, 4xx, 5xx) • Routing (attribute-based, conventional) • Content negotiation |
| **Skill Level**         | Beginner → Intermediate                                                                                                                          |
| **Priority**            | **MUST-KNOW**                                                                                                                                    |
| **REST Best Practices** | • Use correct HTTP verbs • Meaningful status codes • Consistent naming (resources, not actions) • Proper URL structure • Pagination & filtering  |
| **Routing Examples**    | `[HttpGet("api/users/{id}")]` • `[Route("[controller]/[action]")]` • Constraint routing: `{id:int}`                                              |
| **Interview Focus**     | REST principles • HTTP semantics • API versioning strategy • URL design                                                                          |

## 3.2 Controllers & Actions

| Aspect               | Details                                                                                                                                                                                                 |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**            | Controller Architecture & Action Methods                                                                                                                                                                |
| **Description**      | Organize API endpoints in controllers. Understand action filters, model binding, and response handling.                                                                                                 |
| **Key Concepts**     | Controller inheritance (ControllerBase for APIs) • Action results (Ok, BadRequest, NotFound, Created, etc.) • Filters (Authorization, Resource, Action, Result, Exception) • Model binding & validation |
| **Skill Level**      | Beginner → Intermediate                                                                                                                                                                                 |
| **Priority**         | **MUST-KNOW**                                                                                                                                                                                           |
| **Action Results**   | `Ok(data)`, `CreatedAtAction()`, `BadRequest()`, `NotFound()`, `NoContent()`, `Unauthorized()`, `Forbid()`                                                                                              |
| **Filter Order**     | Authorization → Resource → Action → Result → Exception                                                                                                                                                  |
| **Model Validation** | `[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`, `[CustomValidation]`                                                                                                                       |
| **Interview Focus**  | Filter execution order • Dependency injection in controllers • Global error handling with filters                                                                                                       |

## 3.3 Middleware Pipeline

| Aspect                | Details                                                                                                                                        |
| --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**             | Request/Response Pipeline & Custom Middleware                                                                                                  |
| **Description**       | Understand middleware execution order and how to build custom middleware for cross-cutting concerns (logging, error handling, authentication). |
| **Key Concepts**      | Middleware ordering • `Use()` vs `Run()` • `UseWhen()` for conditional • Request/Response inspection • IAsyncResult middleware pattern         |
| **Skill Level**       | Intermediate                                                                                                                                   |
| **Priority**          | **MUST-KNOW**                                                                                                                                  |
| **Standard Pipeline** | Exception Handling → HTTPS Redirection → Static Files → Routing → Authentication → Authorization → Endpoint Routing                            |
| **Custom Middleware** | Implement `InvokeAsync(HttpContext context)` or use inline `app.Use()`                                                                         |
| **Common Middleware** | UseExceptionHandler, UseAuthentication, UseAuthorization, UseHttpsRedirection, UseStaticFiles                                                  |
| **Interview Focus**   | Middleware ordering importance • Design custom middleware • Short-circuit pipeline reasoning                                                   |

## 3.4 Authentication & Authorization

| Aspect                 | Details                                                                                                                                                |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**              | User Identity, Claims, & Access Control                                                                                                                |
| **Description**        | Secure endpoints and control access. JWT, OAuth2, Identity Server, and .NET Identity framework. Essential for any production API.                      |
| **Key Concepts**       | Authentication (who are you) vs Authorization (what can you do) • Claims-based identity • JWT tokens • Cookie authentication • OAuth2 / OpenID Connect |
| **Skill Level**        | Intermediate → Advanced                                                                                                                                |
| **Priority**           | **MUST-KNOW**                                                                                                                                          |
| **.NET Identity**      | User management, roles, claims, two-factor auth, password hashing (bcrypt via AspNetCore.Identity)                                                     |
| **JWT Best Practices** | • Use HTTPS only • Include exp (expiration) & iat (issued at) • Never include secrets in JWT • Use RS256 (asymmetric) for public verification          |
| **Policy-Based Auth**  | `[Authorize(Policy = "AdminOnly")]` • Custom policy handlers • Resource-based authorization                                                            |
| **Interview Focus**    | JWT vs session cookies • Claims-based design • OAuth2 flows • Authorization policies                                                                   |

## 3.5 Configuration & Options Pattern

| Aspect                         | Details                                                                                                                                      |
| ------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                      | Configuration Management with IOptions                                                                                                       |
| **Description**                | Externalize configuration: database connections, API keys, feature flags. Use strongly-typed options pattern over magic strings.             |
| **Key Concepts**               | IConfiguration • IOptions<T> vs IOptionsSnapshot<T> • Configuration providers (JSON, environment, command-line, Consul) • Options validation |
| **Skill Level**                | Beginner → Intermediate                                                                                                                      |
| **Priority**                   | **MUST-KNOW**                                                                                                                                |
| **appsettings.json Structure** | Nested hierarchy matching option classes • Environment-specific files: appsettings.{Environment}.json                                        |
| **Binding Example**            | `services.Configure<DatabaseOptions>(config.GetSection("Database"));`                                                                        |
| **Secrets Management**         | Use User Secrets (dev) → Azure Key Vault (prod) → Environment variables                                                                      |
| **Interview Focus**            | Configuration binding strategy • Options validation • Environment-specific configs                                                           |

## 3.6 Content Negotiation & Serialization

| Aspect               | Details                                                                                                                                         |
| -------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**            | JSON/XML Serialization, Formatting                                                                                                              |
| **Description**      | Handle multiple content types (JSON, XML, etc.). System.Text.Json vs Newtonsoft.Json.                                                           |
| **Key Concepts**     | System.Text.Json (default in .NET 5+) • JsonSerializerOptions • Custom converters • Null handling (IgnoreNullValues) • Property naming policies |
| **Skill Level**      | Intermediate                                                                                                                                    |
| **Priority**         | **SHOULD-KNOW**                                                                                                                                 |
| **System.Text.Json** | Faster, more secure (no code execution by default) vs Newtonsoft (Linq.Json, more flexible)                                                     |
| **Configuration**    | `services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; })`     |
| **Interview Focus**  | JSON serialization tradeoffs • Handling circular references • Date serialization                                                                |

---

# 4. DATA ACCESS

## 4.1 Entity Framework Core (EF Core) Fundamentals

| Aspect                  | Details                                                                                                          |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------- |
| **Topic**               | ORM Basics: DbContext, DbSet, Querying                                                                           |
| **Description**         | Primary ORM for .NET. Map C# objects to database tables. Write type-safe database queries without SQL strings.   |
| **Key Concepts**        | DbContext lifecycle • DbSet<T> queries • LINQ-to-SQL translation • Change tracking • SaveChanges() semantics     |
| **Skill Level**         | Beginner → Intermediate                                                                                          |
| **Priority**            | **MUST-KNOW**                                                                                                    |
| **DbContext Lifecycle** | • Create → Configure mappings → Query/Write → SaveChanges → Dispose                                              |
| **Query Patterns**      | • Lazy evaluation • `AsNoTracking()` for read-only queries (performance) • `Include()` for navigation properties |
| **Common Pitfalls**     | • N+1 query problem (eager load with Include) • Querying disconnected contexts • Over-tracking entities          |
| **Interview Focus**     | DbContext lifecycle • Change tracking • Lazy vs eager loading • Query optimization                               |

## 4.2 Data Mapping & Relationships

| Aspect                       | Details                                                                                                                                        |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                    | Entity Relationships, Fluent API Configuration                                                                                                 |
| **Description**              | Map complex data models: one-to-many, many-to-many, self-referencing. Use Fluent API or Data Annotations.                                      |
| **Key Concepts**             | Foreign keys • Navigation properties • Shadow properties • One-to-Many, Many-to-One, Many-to-Many • Cascade delete • Self-referencing entities |
| **Skill Level**              | Intermediate                                                                                                                                   |
| **Priority**                 | **MUST-KNOW**                                                                                                                                  |
| **Configuration Approaches** | • Data Annotations (`[ForeignKey]`, `[Key]`) • Fluent API (modelBuilder) • Hybrid approach                                                     |
| **Fluent API Example**       | `modelBuilder.Entity<Order>().HasMany(o => o.Items).WithOne(i => i.Order)`                                                                     |
| **Many-to-Many**             | Automatic join table (EF Core 5+) vs explicit join entity                                                                                      |
| **Interview Focus**          | Relationship cardinality • Cascade delete implications • Shadow properties                                                                     |

## 4.3 Migrations & Database Evolution

| Aspect              | Details                                                                                                                  |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| **Topic**           | Code-First Migrations, Schema Versioning                                                                                 |
| **Description**     | Evolve database schema alongside code using migrations. Track schema changes in source control.                          |
| **Key Concepts**    | `Add-Migration`, `Update-Database` • Migration authoring • Idempotency • Data migrations vs schema • Rollback strategies |
| **Skill Level**     | Intermediate                                                                                                             |
| **Priority**        | **MUST-KNOW**                                                                                                            |
| **Best Practices**  | • One migration per feature • Descriptive migration names • Test migrations in CI/CD • Script migrations for audit       |
| **Commands**        | `dotnet ef migrations add InitialCreate` • `dotnet ef database update` • `dotnet ef migrations script`                   |
| **Data Migrations** | Use `migrationBuilder.Sql()` for custom logic within migrations                                                          |
| **Interview Focus** | Zero-downtime migrations • Backward compatibility • Migration testing strategy                                           |

## 4.4 Advanced Querying & Performance

| Aspect                   | Details                                                                                                                                             |
| ------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | Complex Queries, Projections, Optimization                                                                                                          |
| **Description**          | Write efficient queries: projections to DTOs, filtering at database level, avoiding N+1 problems.                                                   |
| **Key Concepts**         | Projection with Select • Filtering & pagination • AsNoTracking for read-only • Batch operations • Split queries                                     |
| **Skill Level**          | Intermediate → Advanced                                                                                                                             |
| **Priority**             | **MUST-KNOW**                                                                                                                                       |
| **Performance Patterns** | • Project to DTO early • Use `GroupBy` at database level • Pagination: `Skip(pageSize * (page-1)).Take(pageSize)` • Indexing strategy in migrations |
| **EF Core 7+ Features**  | • Compiled queries for repeated queries • Bulk operations (EF Core 7+) • Execute Update/Delete (skip change tracking)                               |
| **When to Use Raw SQL**  | Complex reports, CTEs, database-specific features: `context.Database.SqlQuery<T>()`                                                                 |
| **Interview Focus**      | Query optimization • Avoiding N+1 • When to denormalize • Bulk operations performance                                                               |

## 4.5 Database Contexts & Patterns

| Aspect                    | Details                                                                                                           |
| ------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| **Topic**                 | Unit of Work, Repository, DbContext Scoping                                                                       |
| **Description**           | Organize data access code. Scoped DbContext per request in web apps. Consider Repository pattern for abstraction. |
| **Key Concepts**          | DbContext as Unit of Work • Repository pattern • Generic repositories pros/cons • Scoped lifetime in DI           |
| **Skill Level**           | Intermediate                                                                                                      |
| **Priority**              | **SHOULD-KNOW**                                                                                                   |
| **DbContext Scoping**     | Always scoped in DI for web apps (automatic in ASP.NET Core) to prevent data leaks                                |
| **Repository Trade-offs** | • Pros: Testability, abstraction • Cons: Over-engineering, leaky abstraction of LINQ                              |
| **Recommendation**        | For most projects: DbContext directly injected (it already abstracts database), test with InMemory provider       |
| **Interview Focus**       | Repository pattern tradeoffs • DbContext scoping • Testing data access code                                       |

## 4.6 Dapper (Micro-ORM Alternative)

| Aspect                       | Details                                                                                                                                     |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------- |
| **Topic**                    | High-Performance Data Mapping                                                                                                               |
| **Description**              | Lightweight alternative to EF Core for maximum performance. Direct SQL with automatic object mapping. Use when EF overhead is unacceptable. |
| **Key Concepts**             | Raw SQL with parameters • QueryAsync<T>, QueryFirstAsync<T> • Execute for updates • Multiple result sets • Dynamic queries                  |
| **Skill Level**              | Intermediate                                                                                                                                |
| **Priority**                 | **SHOULD-KNOW**                                                                                                                             |
| **When to Use Dapper**       | Performance-critical paths • Stored procedures • Complex SQL queries • Microservices with simple read-only data                             |
| **SQL Injection Protection** | Always use parameters: `@UserId` bound to `new { UserId = id }`                                                                             |
| **Comparison**               | EF Core: abstraction + ORM overhead                                                                                                         | Dapper: thin wrapper, manual SQL but full control |
| **Interview Focus**          | EF vs Dapper tradeoffs • SQL injection prevention • Performance benchmarking                                                                |

---

# 5. ARCHITECTURE & DESIGN PATTERNS

## 5.1 SOLID Principles

| Aspect                    | Details                                                                                                                                                                                                                                                                   |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                 | Design Principles for Maintainable Code                                                                                                                                                                                                                                   |
| **Description**           | Five principles ensuring code is extensible, maintainable, and testable. Foundation of professional software architecture.                                                                                                                                                |
| **Key Concepts**          | **S**ingle Responsibility (one reason to change) • **O**pen/Closed (open for extension, closed for modification) • **L**iskov Substitution (substitutable subtypes) • **I**nterface Segregation (specific interfaces) • **D**ependency Inversion (depend on abstractions) |
| **Skill Level**           | Intermediate → Advanced                                                                                                                                                                                                                                                   |
| **Priority**              | **MUST-KNOW**                                                                                                                                                                                                                                                             |
| **Single Responsibility** | Each class has one reason to change. Separate concerns: persistence, business logic, validation.                                                                                                                                                                          |
| **Open/Closed**           | Use inheritance, interfaces, composition for extension without modifying existing code.                                                                                                                                                                                   |
| **Liskov Substitution**   | Derived classes must be substitutable for base classes without breaking behavior. Avoid violating preconditions/postconditions.                                                                                                                                           |
| **Interface Segregation** | Clients shouldn't depend on methods they don't use. Create focused, specific interfaces.                                                                                                                                                                                  |
| **Dependency Inversion**  | Depend on abstractions (interfaces), not concrete implementations. Enables testing & swapping implementations.                                                                                                                                                            |
| **Interview Focus**       | Identify SOLID violations in code • Refactor monolithic class per principle • Design interfaces properly                                                                                                                                                                  |

## 5.2 Common Design Patterns

| Aspect                      | Details                                                                                                                                                                                                       |
| --------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                   | Creational, Structural, Behavioral Patterns                                                                                                                                                                   |
| **Description**             | Proven solutions to recurring design problems. Communicate solutions efficiently. Know when to apply each.                                                                                                    |
| **Key Concepts**            | **Creational:** Factory, Builder, Singleton, Prototype • **Structural:** Adapter, Bridge, Composite, Decorator, Facade, Proxy • **Behavioral:** Observer, Strategy, Command, State, Template Method, Iterator |
| **Skill Level**             | Intermediate → Advanced                                                                                                                                                                                       |
| **Priority**                | **MUST-KNOW**                                                                                                                                                                                                 |
| **Factory Pattern**         | Decouple object creation from usage. Example: `IUserFactory.CreateUser()`                                                                                                                                     |
| **Builder Pattern**         | Complex object construction. Fluent API. Example: StringBuilder, configuration builders.                                                                                                                      |
| **Decorator Pattern**       | Add behavior dynamically. Example: Logging decorator wrapping service.                                                                                                                                        |
| **Strategy Pattern**        | Runtime behavior selection. Example: Different payment processors (Stripe, PayPal).                                                                                                                           |
| **Observer Pattern**        | Event-driven architecture. Example: Event handlers, pub/sub.                                                                                                                                                  |
| **Repository/Unit of Work** | Data access abstraction. Example: EF Core DbContext.                                                                                                                                                          |
| **Interview Focus**         | When to apply each pattern • Anti-patterns to avoid • Real-world implementations                                                                                                                              |

## 5.3 Clean Architecture

| Aspect              | Details                                                                                                                                                                                    |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**           | Layered Architecture, Separation of Concerns                                                                                                                                               |
| **Description**     | Organize code into independent layers: Entities, Use Cases, Interface Adapters, Frameworks. Testable, maintainable, framework-agnostic core logic.                                         |
| **Key Concepts**    | Dependency Rule (inward dependencies only) • Entities (pure business rules) • Use Cases (application logic) • Adapters (controllers, presenters) • External Systems (DB, frameworks)       |
| **Skill Level**     | Intermediate → Advanced                                                                                                                                                                    |
| **Priority**        | **SHOULD-KNOW**                                                                                                                                                                            |
| **Layer Breakdown** | • Core/Domain: Entities, business rules (no framework dependencies) • Application: Use cases, orchestration • Infrastructure: DB, external services • Presentation: API controllers, views |
| **Benefits**        | Framework-independent core • Testable • Easy to understand • Maintainable • Replaceable components                                                                                         |
| **In .NET Context** | • Domain layer: DTOs, Value Objects • Application: Services, Handlers • Infrastructure: EF Core DbContext, repositories • API: Controllers                                                 |
| **Interview Focus** | Layer design • Dependency direction • Testing strategies per layer                                                                                                                         |

## 5.4 Domain-Driven Design (DDD)

| Aspect                 | Details                                                                                                                              |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**              | Modeling Complex Business Domains                                                                                                    |
| **Description**        | Design system around business domain using Ubiquitous Language. Enforce invariants, aggregate roots, bounded contexts.               |
| **Key Concepts**       | Entity vs Value Object • Aggregate Root • Repository (abstracts persistence) • Domain Events • Bounded Context • Ubiquitous Language |
| **Skill Level**        | Advanced                                                                                                                             |
| **Priority**           | **SHOULD-KNOW**                                                                                                                      |
| **Entity**             | Has identity (ID). Mutable. Example: User, Order. Implements `IEquatable<T>` based on ID.                                            |
| **Value Object**       | No identity. Immutable. Example: Money, Address. Equality by value.                                                                  |
| **Aggregate Root**     | Entity owning related entities. Enforces consistency boundary. Example: Order (root) → Items (child entities).                       |
| **Domain Events**      | Events representing significant business occurrences. Example: OrderPlaced, PaymentProcessed.                                        |
| **Bounded Context**    | Explicit boundary around domain model. Different bounded contexts can model same concept differently.                                |
| **Repository Pattern** | Abstract persistence. Aggregate-level, not entity-level. Example: `IOrderRepository.GetById()` returns entire aggregate.             |
| **Interview Focus**    | Aggregate design • Enforcing invariants • Domain event handling • Bounded context boundaries                                         |

## 5.5 CQRS (Command Query Responsibility Segregation)

| Aspect              | Details                                                                                                                             |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | Separating Read & Write Models                                                                                                      |
| **Description**     | Split into Command side (writes) and Query side (reads). Optimize each independently. Powerful for complex domains and scaling.     |
| **Key Concepts**    | Commands (intent to change state) • Queries (data retrieval) • Event sourcing • Denormalization for queries • Eventual consistency  |
| **Skill Level**     | Advanced                                                                                                                            |
| **Priority**        | **NICE-TO-KNOW** → **SHOULD-KNOW** for senior architects                                                                            |
| **Command Side**    | Enforces business rules. Events published. Normalized data. Slow writes, consistency guaranteed.                                    |
| **Query Side**      | Denormalized read model. Fast queries. Updated eventually via events.                                                               |
| **Benefits**        | Scalability (read/write separately) • Optimization (different strategies) • Clear intent (commands explicit) • Audit trail (events) |
| **Libraries**       | MediatR for CQRS pattern • EventStore for event sourcing • Marten for event sourcing in .NET                                        |
| **Interview Focus** | When CQRS is overkill vs justified • Event consistency • Query model synchronization                                                |

## 5.6 Microservices Architecture

| Aspect                  | Details                                                                                                                                                   |
| ----------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**               | Distributed Systems, Service Boundaries                                                                                                                   |
| **Description**         | Decompose monolith into small, independent services. Each service owns data, technology stack, deployment.                                                |
| **Key Concepts**        | Service autonomy • API gateways • Service-to-service communication (HTTP, messaging) • Eventual consistency • Distributed transactions • Circuit breakers |
| **Skill Level**         | Advanced                                                                                                                                                  |
| **Priority**            | **SHOULD-KNOW**                                                                                                                                           |
| **Service Design**      | Single responsibility • Own database • Async communication preferred • Stateless, scalable                                                                |
| **Inter-Service Calls** | RESTful APIs • gRPC for performance • Message buses (RabbitMQ, Azure Service Bus) for async                                                               |
| **Challenges**          | Distributed debugging • Eventual consistency • Network latency • Deployment complexity                                                                    |
| **Patterns**            | API Gateway (routing) • Service Registry (discovery) • Circuit Breaker (failure handling) • Saga (distributed transactions)                               |
| **Interview Focus**     | When to use microservices vs monolith • Service boundaries • Inter-service communication • Handling failures                                              |

---

# 6. TESTING

## 6.1 Unit Testing Fundamentals

| Aspect                | Details                                                                                                                                                            |
| --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**             | Testing Individual Units (Functions, Classes)                                                                                                                      |
| **Description**       | Fast, isolated tests ensuring code correctness. Foundation of test pyramid. Use xUnit or NUnit.                                                                    |
| **Key Concepts**      | Arrange-Act-Assert (AAA) pattern • Test naming conventions • Mocking vs Stubbing • Assertion libraries • Test data builders                                        |
| **Skill Level**       | Beginner → Intermediate                                                                                                                                            |
| **Priority**          | **MUST-KNOW**                                                                                                                                                      |
| **Frameworks**        | xUnit (recommended, modern) vs NUnit (traditional) vs MSTest (Microsoft)                                                                                           |
| **Mocking Libraries** | Moq (most popular) • NSubstitute • FakeItEasy                                                                                                                      |
| **Test Naming**       | `[Fact]` for parameterless • `[Theory] [InlineData(...)]` for parameterized • Convention: MethodName_Condition_ExpectedResult                                      |
| **AAA Pattern**       | **Arrange:** Setup objects → **Act:** Call method → **Assert:** Verify result                                                                                      |
| **Best Practices**    | • One assertion per test (or related assertions) • Test behavior, not implementation • No test interdependencies • Mock external dependencies, test business logic |
| **Interview Focus**   | Write unit test from specification • Mock complex dependencies • Test naming • Coverage goals (70-80%)                                                             |

## 6.2 Integration Testing

| Aspect              | Details                                                                                                                        |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**           | Testing Components Together (Database, APIs, Messaging)                                                                        |
| **Description**     | Test multiple components integrated. Slower than unit tests. Essential for validating system interactions.                     |
| **Key Concepts**    | In-memory databases (EF Core InMemory) • Test containers (Testcontainers) • Fixtures • Database seeding • API endpoint testing |
| **Skill Level**     | Intermediate                                                                                                                   |
| **Priority**        | **MUST-KNOW**                                                                                                                  |
| **EF Core Testing** | Use InMemory provider for speed or real database with migration setup                                                          |
| **API Testing**     | `WebApplicationFactory<Program>` for ASP.NET Core in-process testing                                                           |
| **Testcontainers**  | Docker-based: SQL Server, PostgreSQL, Redis, RabbitMQ in tests. Better than mocking real services.                             |
| **Database Setup**  | Use migrations in test setup • Separate test database • Seed consistent test data                                              |
| **Best Practices**  | • Test through public APIs • Use real databases when possible (Testcontainers) • Isolate test data • Clean up after tests      |
| **Interview Focus** | Integration test strategy • Testing database code • API contract testing                                                       |

## 6.3 Mocking & Test Doubles

| Aspect               | Details                                                                                                                                          |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**            | Mocks, Stubs, Fakes, Spies                                                                                                                       |
| **Description**      | Replace external dependencies with test doubles. Isolate code under test. Verify interactions.                                                   |
| **Key Concepts**     | Mock (verifies behavior calls) • Stub (returns canned responses) • Fake (working implementation) • Spy (records calls) • Matchers & verification |
| **Skill Level**      | Intermediate                                                                                                                                     |
| **Priority**         | **MUST-KNOW**                                                                                                                                    |
| **Moq Examples**     | `new Mock<IUserService>().Setup(x => x.GetUser(id)).ReturnsAsync(user)` • Verify calls: `.Verify(x => x.SaveUser(...))`                          |
| **When Not to Mock** | Don't mock classes you own (test real instances) • Mock external services (APIs, databases) • Mock only at boundaries                            |
| **Pitfalls**         | • Over-mocking (brittle tests) • Mocking implementation details • Tests coupled to implementation                                                |
| **Best Practices**   | • Mock interfaces, not concrete classes • Use Moq matchers for flexibility (It.IsAny) • Verify only important interactions                       |
| **Interview Focus**  | Mock vs Stub distinction • Over-mocking problems • Designing for testability (interfaces)                                                        |

## 6.4 Test Organization & Patterns

| Aspect                 | Details                                                                                                                              |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**              | Test Project Structure, Fixtures, Data Builders                                                                                      |
| **Description**        | Organize tests for clarity and maintainability. Use fixtures and builders for common setup.                                          |
| **Key Concepts**       | Test project structure mirroring source • Shared fixtures (ICollectionFixture) • Test data builders • Page Object pattern (UI tests) |
| **Skill Level**        | Intermediate                                                                                                                         |
| **Priority**           | **SHOULD-KNOW**                                                                                                                      |
| **Project Structure**  | Tests/UnitTests/, Tests/IntegrationTests/, Tests/E2ETests/. Mirror namespace structure.                                              |
| **Fixtures**           | `IAsyncLifetime` for async setup/teardown • Shared fixtures across test classes • Context-per-test vs context-per-class              |
| **Test Data Builders** | Fluent builders reducing test setup boilerplate. Example: `new UserBuilder().WithEmail("test@test.com").Build()`                     |
| **Interview Focus**    | Test organization strategy • Fixture design • Maintaining test code quality                                                          |

## 6.5 End-to-End & Performance Testing

| Aspect              | Details                                                                                                                                                        |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | Full System Testing, Load Testing, Monitoring                                                                                                                  |
| **Description**     | Test entire system end-to-end. Verify performance. Monitor in production.                                                                                      |
| **Key Concepts**    | E2E test tools (Selenium, Playwright, BDD frameworks) • Load testing (k6, Apache JMeter) • Stress testing • Performance profiling • Monitoring & observability |
| **Skill Level**     | Intermediate → Advanced                                                                                                                                        |
| **Priority**        | **SHOULD-KNOW**                                                                                                                                                |
| **E2E Tools**       | Selenium (browser automation) • Playwright (modern, fast) • SpecFlow (BDD/Gherkin) for business-readable tests                                                 |
| **Load Testing**    | k6 scripting • JMeter GUI • LoadRunner. Test under realistic load.                                                                                             |
| **Profiling Tools** | .NET Profiler (Visual Studio) • dotTrace • Memory analysis tools (dotMemory)                                                                                   |
| **Interview Focus** | Performance testing strategy • When E2E is valuable vs expensive • Production monitoring approach                                                              |

---

# 7. PERFORMANCE & OPTIMIZATION

## 7.1 Async/Await Optimization

| Aspect                    | Details                                                                                                                                 |
| ------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                 | Scalable I/O Patterns, ValueTask                                                                                                        |
| **Description**           | Write non-blocking code to serve thousands of concurrent requests. Use ValueTask for hot paths. Avoid blocking thread pool.             |
| **Key Concepts**          | Async all the way • ConfigureAwait(false) in libraries • ValueTask vs Task • Allocations from Task creation • Thread pool starvation    |
| **Skill Level**           | Intermediate → Advanced                                                                                                                 |
| **Priority**              | **MUST-KNOW**                                                                                                                           |
| **ConfigureAwait(false)** | Library code: always use to avoid capturing synchronization context, improve performance. Web apps: usually not needed (already async). |
| **ValueTask**             | Allocation-free for synchronous completions. Use for hot paths, HAL allocations sensitive code. Example: cached data returns.           |
| **Thread Pool Awareness** | Understanding scheduling • Avoiding `Task.Run()` in async chains • Custom thread pools for specific workloads                           |
| **Interview Focus**       | When ConfigureAwait matters • ValueTask usage • Async library design                                                                    |

## 7.2 Memory & Allocation Optimization

| Aspect                  | Details                                                                                                                                              |
| ----------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**               | Heap Allocations, GC Pressure, Pooling                                                                                                               |
| **Description**         | Reduce allocations to improve performance and reduce GC pressure. Understand allocation sources. Use object pooling for repeated allocations.        |
| **Key Concepts**        | Allocation sources (boxing, closures, foreach, delegates) • Span<T>, Memory<T>, stackalloc • ArrayPool<T> • Object pooling • Gen 0, 1, 2 collections |
| **Skill Level**         | Advanced                                                                                                                                             |
| **Priority**            | **SHOULD-KNOW**                                                                                                                                      |
| **Boxing**              | Avoid boxing value types (List<int> vs List<object>) • Generics prevent boxing                                                                       |
| **Span<T> & Memory<T>** | Stack-allocated slices without copying. Example: `Span<byte> buffer = stackalloc byte[256]`                                                          |
| **ArrayPool**           | Rent/return arrays instead of allocating. Excellent for temporary buffers.                                                                           |
| **Object Pooling**      | Reuse expensive objects (StringBuilder, HttpClient). Libraries: ObjectPool<T> (Microsoft), custom implementations.                                   |
| **Measurement**         | Use profiler: allocations per operation, Gen 2 collections, GC pause times                                                                           |
| **Interview Focus**     | Allocation sources in your code • Span vs Memory • When pooling is justified                                                                         |

## 7.3 Caching Strategies

| Aspect                 | Details                                                                                                                        |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**              | In-Process, Distributed, HTTP Caching                                                                                          |
| **Description**        | Reduce expensive operations (DB queries, API calls). L1 cache (in-process), L2 cache (Redis), HTTP cache.                      |
| **Key Concepts**       | Cache invalidation strategies • TTL (Time To Live) • Cache-aside vs Write-through vs Write-behind • Thundering Herd prevention |
| **Skill Level**        | Intermediate → Advanced                                                                                                        |
| **Priority**           | **MUST-KNOW**                                                                                                                  |
| **In-Process Cache**   | `IMemoryCache` in ASP.NET Core • Set with absolute/sliding expiration • Risk: stale data if not invalidated                    |
| **Distributed Cache**  | Redis (recommended) via `IDistributedCache` • Shared across multiple instances • Persistent (survives restarts)                |
| **HTTP Caching**       | Cache-Control headers • ETag validation • 304 Not Modified responses • Browser & proxy caching                                 |
| **Cache Invalidation** | "Only hard problem in CS" • Time-based (TTL) • Event-based (invalidate on write) • Pattern-based (invalidate by pattern)       |
| **Thundering Herd**    | Multiple requests for expired cache key simultaneously. Prevention: Probabilistic early expiration, locks, async refresh.      |
| **Interview Focus**    | Cache invalidation strategy • Distributed vs in-process • Cache coherence across instances                                     |

## 7.4 Database Query Optimization

| Aspect                   | Details                                                                                                                                                                   |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | Query Performance, Indexing, Execution Plans                                                                                                                              |
| **Description**          | Write efficient SQL. Use indexes. Understand query execution plans. Identify N+1 problems.                                                                                |
| **Key Concepts**         | Query execution plans • Index strategy (composite, covering) • Missing index analysis • Parameterized queries (SQL injection prevention) • Query timeouts                 |
| **Skill Level**          | Intermediate → Advanced                                                                                                                                                   |
| **Priority**             | **MUST-KNOW**                                                                                                                                                             |
| **EF Core Optimization** | • Eager load with `Include()` prevent N+1 • Project with `Select()` to reduce data transfer • Use `AsNoTracking()` for read-only • Compiled queries for repeated patterns |
| **SQL Indexes**          | • Primary key (clustered) • Unique constraints • Foreign keys indexed (lookups) • Covering indexes (include non-key columns)                                              |
| **Execution Plans**      | Read from actual (not estimated) plans • Look for scans vs seeks • High IO vs CPU • Identify bottlenecks                                                                  |
| **Query Anti-patterns**  | • Functions in WHERE clause prevent index usage • Wildcard prefix `LIKE '%text'` scans • Implicit type conversions • Correlated subqueries                                |
| **Interview Focus**      | Optimize slow query • Design indexes • Explain query plan reading                                                                                                         |

## 7.5 Profiling & Benchmarking

| Aspect                   | Details                                                                                                                                |
| ------------------------ | -------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | Measuring Performance, Finding Bottlenecks                                                                                             |
| **Description**          | Use tools to measure performance. Don't guess. Benchmark before/after optimization. Focus on actual bottlenecks.                       |
| **Key Concepts**         | Profilers (CPU, memory, I/O) • BenchmarkDotNet for micro-benchmarks • Tracing tools (ETW) • Production profiling • Apdex score         |
| **Skill Level**          | Advanced                                                                                                                               |
| **Priority**             | **SHOULD-KNOW**                                                                                                                        |
| **BenchmarkDotNet**      | `[Benchmark]` attribute • Warmup runs • Iteration count • Statistical analysis (mean, StdDev) • Prevent optimization by compiler       |
| **Profilers**            | Visual Studio Profiler • dotTrace (JetBrains) • Stackify, DataDog for APM • Memory: dotMemory                                          |
| **Measurements**         | Wall-clock time • CPU time • Memory allocations • GC collections • Thread count                                                        |
| **Production Profiling** | Sampling vs instrumentation tradeoff • APM tools (Application Insights, Datadog) • Continuous profiling (Continuous Code Optimization) |
| **Interview Focus**      | How to profile code • Interpret benchmark results • When optimization effort justified                                                 |

---

# 8. CLOUD & DevOps

## 8.1 Azure Services for .NET

| Aspect                   | Details                                                                                                                                                 |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | App Service, SQL Database, Key Vault, Application Insights                                                                                              |
| **Description**          | Deploy .NET applications to Azure. Understand managed services vs IaaS.                                                                                 |
| **Key Concepts**         | App Service (PaaS) • Azure SQL Database (managed relational) • Cosmos DB (NoSQL) • App Configuration • Key Vault (secrets) • Application Insights (APM) |
| **Skill Level**          | Intermediate → Advanced                                                                                                                                 |
| **Priority**             | **SHOULD-KNOW**                                                                                                                                         |
| **App Service**          | Serverless-like PaaS • Auto-scaling • Always-on option • Deployment slots (staging, production) • ARM templates for infrastructure-as-code              |
| **Azure SQL Database**   | Managed relational database • Automated backups, patching • Point-in-time restore • Read replicas for scaling reads                                     |
| **Key Vault**            | Store secrets, keys, certificates • Rotate without code changes • Audit access • Managed identity integration                                           |
| **Application Insights** | APM (Application Performance Monitoring) • Request tracking • Exception tracking • Custom metrics • Alerts                                              |
| **Managed Identity**     | Authentication without credentials in config • Role-based access control (RBAC) • Integration with Key Vault, databases                                 |
| **Interview Focus**      | App Service scalability • Key Vault integration • Application Insights dashboards                                                                       |

## 8.2 Containerization with Docker

| Aspect                 | Details                                                                                                                 |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------------- |
| **Topic**              | Dockerizing .NET Applications, Multi-Stage Builds                                                                       |
| **Description**        | Package application in containers for consistent deployment. Multi-stage builds optimize image size.                    |
| **Key Concepts**       | Dockerfile syntax • Base images (alpine, debian) • Layers & caching • Multi-stage builds • .dockerignore                |
| **Skill Level**        | Intermediate                                                                                                            |
| **Priority**           | **MUST-KNOW**                                                                                                           |
| **Dockerfile Example** |                                                                                                                         |
|                        | `FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build`                                                                        |
|                        | `WORKDIR /src`                                                                                                          |
|                        | `COPY ["MyApp.csproj", "."]`                                                                                            |
|                        | `RUN dotnet restore`                                                                                                    |
|                        | `COPY . .`                                                                                                              |
|                        | `RUN dotnet build -c Release -o /app/build`                                                                             |
|                        | `FROM mcr.microsoft.com/dotnet/aspnet:8.0`                                                                              |
|                        | `COPY --from=build /app/build .`                                                                                        |
|                        | `ENTRYPOINT ["dotnet", "MyApp.dll"]`                                                                                    |
| **Base Images**        | SDK (build) vs Runtime (run) • Alpine (small) vs Debian (compatibility)                                                 |
| **Layer Optimization** | Order matters for caching • Dependency restore before code copy • .dockerignore excludes large folders (bin, obj, .git) |
| **Image Size**         | Typical ASP.NET Core: 50-150MB (alpine smaller)                                                                         |
| **Interview Focus**    | Multi-stage build reasoning • Image size optimization • Layer caching                                                   |

## 8.3 CI/CD Pipelines

| Aspect                       | Details                                                                                                                                                 |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                    | GitHub Actions, Azure Pipelines, GitLab CI                                                                                                              |
| **Description**              | Automate build, test, deploy. Fast feedback. Consistent deployments. GitOps principles.                                                                 |
| **Key Concepts**             | Build pipeline (compile, test, package) • Artifact repositories (NuGet, Docker registries) • Deployment stages (dev, staging, prod) • Approval gates    |
| **Skill Level**              | Intermediate                                                                                                                                            |
| **Priority**                 | **MUST-KNOW**                                                                                                                                           |
| **GitHub Actions (Example)** |                                                                                                                                                         |
|                              | `on: [push, pull_request]`                                                                                                                              |
|                              | `jobs:`                                                                                                                                                 |
|                              | `  build:`                                                                                                                                              |
|                              | `    runs-on: ubuntu-latest`                                                                                                                            |
|                              | `    steps:`                                                                                                                                            |
|                              | `      - uses: actions/checkout@v3`                                                                                                                     |
|                              | `      - uses: actions/setup-dotnet@v3`                                                                                                                 |
|                              | `      - run: dotnet build`                                                                                                                             |
|                              | `      - run: dotnet test`                                                                                                                              |
| **Azure Pipelines**          | YAML-based (modern) or classic UI • Variables for environments • Approval gates for prod deployment                                                     |
| **Best Practices**           | • Code review before merge (pull requests) • Automated tests in pipeline (fast fail) • Staging environment tests • Gradual rollout (blue-green, canary) |
| **Secrets Management**       | Azure Key Vault / GitHub Secrets • Never commit credentials • Rotate regularly                                                                          |
| **Interview Focus**          | Pipeline stages design • Deployment strategy • Rollback plan                                                                                            |

## 8.4 Infrastructure as Code (IaC)

| Aspect              | Details                                                                                                                         |
| ------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | ARM Templates, Terraform, Bicep                                                                                                 |
| **Description**     | Define infrastructure in code. Version control. Reproducible deployments.                                                       |
| **Key Concepts**    | Declarative IaC • Version control infrastructure • Terraform state management • Bicep (ARM alternative) • Resource dependencies |
| **Skill Level**     | Intermediate → Advanced                                                                                                         |
| **Priority**        | **SHOULD-KNOW**                                                                                                                 |
| **Terraform**       | Cloud-agnostic (AWS, Azure, GCP) • State file (track changes) • Variables, outputs, modules • terraform plan/apply              |
| **Bicep**           | Azure-specific • More concise than ARM JSON • Strong typing • Module reuse                                                      |
| **ARM Templates**   | Azure-native JSON • Complex, verbose • Good for Azure-only projects • Integration with Pipelines                                |
| **Best Practices**  | • Version control IaC • Parameterize for reuse • Module structure • Test infrastructure code                                    |
| **Interview Focus** | IaC benefits vs manual • Terraform state management • Module design                                                             |

## 8.5 Kubernetes Basics (K8s)

| Aspect              | Details                                                                                                            |
| ------------------- | ------------------------------------------------------------------------------------------------------------------ |
| **Topic**           | Container Orchestration, Deployment Manifests                                                                      |
| **Description**     | Deploy, scale, manage containerized applications. Declarative configuration. Auto-scaling, self-healing.           |
| **Key Concepts**    | Pods, Services, Deployments • ConfigMaps, Secrets • Ingress • Persistent Volumes • Horizontal Pod Autoscaler (HPA) |
| **Skill Level**     | Advanced                                                                                                           |
| **Priority**        | **NICE-TO-KNOW** → **SHOULD-KNOW** for cloud-native development                                                    |
| **Deployment YAML** |                                                                                                                    |
|                     | `apiVersion: apps/v1`                                                                                              |
|                     | `kind: Deployment`                                                                                                 |
|                     | `metadata:`                                                                                                        |
|                     | `  name: myapp`                                                                                                    |
|                     | `spec:`                                                                                                            |
|                     | `  replicas: 3`                                                                                                    |
|                     | `  template:`                                                                                                      |
|                     | `    spec:`                                                                                                        |
|                     | `      containers:`                                                                                                |
|                     | `      - name: myapp`                                                                                              |
|                     | `        image: myapp:1.0`                                                                                         |
|                     | `        ports:`                                                                                                   |
|                     | `        - containerPort: 80`                                                                                      |
| **Pod**             | Smallest unit, usually single container • Network shared (localhost) • Ephemeral (destroyed with deployment)       |
| **Service**         | Stable endpoint for pods • Load balancing • DNS discovery                                                          |
| **Ingress**         | HTTP/S routing to services • URL-based routing • SSL termination                                                   |
| **StatefulSets**    | Stable identities, persistent storage. For databases, message queues.                                              |
| **Interview Focus** | Deployment strategy • Scaling strategy • Resource limits • Health checks                                           |

---

# 9. SECURITY

## 9.1 Authentication Mechanisms

| Aspect                 | Details                                                                                                                                                                       |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**              | JWT, OAuth2, OpenID Connect, Session Cookies                                                                                                                                  |
| **Description**        | Verify user identity. Choose appropriate mechanism: stateful vs stateless, symmetric vs asymmetric.                                                                           |
| **Key Concepts**       | JWT structure (header.payload.signature) • OAuth2 flows (Authorization Code, Client Credentials, PKCE) • OpenID Connect (authentication layer over OAuth2)                    |
| **Skill Level**        | Intermediate → Advanced                                                                                                                                                       |
| **Priority**           | **MUST-KNOW**                                                                                                                                                                 |
| **JWT Best Practices** | • Asymmetric signing (RS256) for public verification • Include exp, iat, jti claims • HTTPS only transmission • Short expiry (15-60 min), refresh token for longer access     |
| **JWT vs Session**     | JWT: stateless, scalable, mobile-friendly, smaller • Session: stateful, invalidation easier, larger cookies                                                                   |
| **OAuth2 Flows**       | • Authorization Code (web apps, confidential clients) • Implicit (legacy, insecure) • Client Credentials (service-to-service) • PKCE (mobile/SPA, prevents code interception) |
| **OpenID Connect**     | OAuth2 + Identity layer • ID token (authentication) • User info endpoint • Discovery document                                                                                 |
| **ASP.NET Identity**   | User management, roles, two-factor auth, password hashing (bcrypt)                                                                                                            |
| **Interview Focus**    | JWT vs session tradeoffs • OAuth2 flow selection • Token refresh strategy • PKCE importance                                                                                   |

## 9.2 Authorization & Access Control

| Aspect              | Details                                                                                                                                                    |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | Role-Based, Claim-Based, Resource-Based Authorization                                                                                                      |
| **Description**     | Control what authenticated users can do. Role-based vs claims-based vs resource-based strategies.                                                          |
| **Key Concepts**    | Roles (high-level, e.g., Admin, User) • Claims (fine-grained, e.g., "department:sales") • Policies (combinations of claims) • Resource-based authorization |
| **Skill Level**     | Intermediate                                                                                                                                               |
| **Priority**        | **MUST-KNOW**                                                                                                                                              |
| **Role-Based**      | Simple, coarse-grained. `[Authorize(Roles = "Admin")]`. Inflexible for complex rules.                                                                      |
| **Claim-Based**     | Fine-grained. Claims in JWT. Example: `[Authorize(AuthenticationSchemes = "Bearer", Policy = "SalesOnly")]` checking claims.                               |
| **Policy-Based**    | Custom policies combining multiple claims. `[Authorize(Policy = "Over18AndPremium")]`                                                                      |
| **Resource-Based**  | Determine authorization after loading resource. Example: "can edit only your own post". Implement in handler.                                              |
| **Implementation**  | ASP.NET Core `AuthorizationHandler<TRequirement>` • Custom policies • Attribute-based `[Authorize]`                                                        |
| **Interview Focus** | Authorization strategy design • When role vs claim vs resource-based • Custom policies                                                                     |

## 9.3 Encryption & Hashing

| Aspect                    | Details                                                                                                                                                                   |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                 | Symmetric/Asymmetric Encryption, Password Hashing                                                                                                                         |
| **Description**           | Protect sensitive data. Encrypt PII, passwords. Hash for one-way security.                                                                                                |
| **Key Concepts**          | Symmetric (AES, same key encrypt/decrypt) • Asymmetric (RSA, public key encrypt, private key decrypt) • Hashing (bcrypt, PBKDF2, Argon2) • Key management                 |
| **Skill Level**           | Intermediate → Advanced                                                                                                                                                   |
| **Priority**              | **MUST-KNOW**                                                                                                                                                             |
| **Password Hashing**      | Never store plain passwords • Bcrypt (recommended, adaptive) • PBKDF2 (Microsoft standard) • Argon2 (latest, resistant to GPU/ASIC attacks) • Salt included automatically |
| **ASP.NET Identity**      | Uses PBKDF2 by default • `PasswordHasher<User>` for hashing                                                                                                               |
| **Symmetric Encryption**  | AES-256 for data encryption (PII in database) • Key management critical (store in Key Vault)                                                                              |
| **Asymmetric Encryption** | RSA for key exchange • JWT signing (RS256) • Client-server secure communication                                                                                           |
| **HTTPS/TLS**             | Asymmetric handshake, symmetric bulk encryption • Always use in production                                                                                                |
| **Interview Focus**       | When to encrypt vs hash • Key management strategy • Password storage • Certificate management                                                                             |

## 9.4 Input Validation & Output Encoding

| Aspect               | Details                                                                                                                                                                   |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**            | Prevent Injection Attacks, XSS, CSRF                                                                                                                                      |
| **Description**      | Validate all inputs. Encode outputs. Prevent injection, XSS, CSRF attacks. Defense in depth.                                                                              |
| **Key Concepts**     | Input validation (whitelist, type, length) • SQL injection prevention (parameterized queries) • XSS prevention (HTML encoding) • CSRF prevention (tokens) • CORS security |
| **Skill Level**      | Intermediate → Advanced                                                                                                                                                   |
| **Priority**         | **MUST-KNOW**                                                                                                                                                             |
| **Input Validation** | Whitelist acceptable values • Type conversion with strong typing • Length limits • Pattern validation (regex for emails, etc.)                                            |
| **SQL Injection**    | Always use parameterized queries: `new { @UserId }` in Dapper, LINQ in EF Core prevents this                                                                              |
| **XSS Prevention**   | HTML-encode user input before displaying • Use Anti-XSS library in .NET • Content Security Policy (CSP) headers                                                           |
| **CSRF Prevention**  | Tokens in forms • Same-site cookies (newer approach) • ASP.NET Core: `[ValidateAntiForgeryToken]`                                                                         |
| **CORS**             | Control cross-origin requests • `[EnableCors("PolicyName")]` • Don't use `AllowAnyOrigin` with credentials                                                                |
| **Security Headers** | `X-Frame-Options: DENY` (prevent clickjacking) • `X-Content-Type-Options: nosniff` • `Strict-Transport-Security: max-age=...` (HSTS)                                      |
| **Interview Focus**  | SQL injection prevention • XSS attack vectors • CSRF protection • Security header importance                                                                              |

## 9.5 Secure Development Practices

| Aspect                  | Details                                                                                                                                                                                                                                                     |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**               | OWASP Top 10, Dependency Scanning, Secrets Management                                                                                                                                                                                                       |
| **Description**         | Build security into development lifecycle. Scan dependencies, manage secrets properly, code review security.                                                                                                                                                |
| **Key Concepts**        | OWASP Top 10 vulnerabilities • Dependency scanning (Snyk, GitHub Dependabot) • Secret scanning (prevent commits) • Security headers • HTTPS enforcement                                                                                                     |
| **Skill Level**         | Intermediate → Advanced                                                                                                                                                                                                                                     |
| **Priority**            | **MUST-KNOW**                                                                                                                                                                                                                                               |
| **OWASP Top 10**        | • Injection (SQL, OS command) • Broken authentication • Sensitive data exposure • XML external entities • Broken access control • Security misconfiguration • XSS • Insecure deserialization • Using components with vulnerabilities • Insufficient logging |
| **Dependency Scanning** | Automated: GitHub Dependabot, Snyk, WhiteSource • Manual: `dotnet list package --vulnerable`                                                                                                                                                                |
| **Secret Management**   | Never commit `.env`, keys, tokens • Use environment variables (dev) → Azure Key Vault (prod) • GitHub secret scanning detects commits                                                                                                                       |
| **Secrets Rotation**    | Rotate keys, tokens regularly • Application shouldn't store credentials • Use Managed Identity when possible                                                                                                                                                |
| **HTTPS Only**          | `app.UseHttpsRedirection()` • HSTS headers • Certificate management                                                                                                                                                                                         |
| **Interview Focus**     | OWASP vulnerabilities in code • Dependency security • Secret rotation strategy                                                                                                                                                                              |

---

# 10. MODERN .NET 8/9 FEATURES

## 10.1 Minimal APIs

| Aspect                  | Details                                                                                                                         |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| **Topic**               | Simplified API Creation, No Controllers                                                                                         |
| **Description**         | Build lightweight APIs without controller classes. Functional programming style. Lower boilerplate, faster for simple APIs.     |
| **Key Concepts**        | `MapGet()`, `MapPost()`, `MapPut()`, `MapDelete()` • Results helper • Dependency injection inline • Filters (extension methods) |
| **Skill Level**         | Intermediate                                                                                                                    |
| **Priority**            | **SHOULD-KNOW**                                                                                                                 |
| **Example**             |                                                                                                                                 |
|                         | `app.MapGet("/api/users/{id}", async (int id, IUserService userService) =>`                                                     |
|                         | `    await userService.GetUserAsync(id) is User user`                                                                           |
|                         | `        ? Results.Ok(user)`                                                                                                    |
|                         | `        : Results.NotFound());`                                                                                                |
| **Advantages**          | Less code, simpler testing, faster startup, lower memory                                                                        |
| **Disadvantages**       | Less structure for large APIs, need discipline to organize, no attributes for documentation                                     |
| **When to Use**         | Microservices, simple CRUD APIs, greenfield projects • Not for large monolithic APIs requiring heavy structure                  |
| **OpenAPI Integration** | `builder.Services.AddOpenApi()` • Automatic documentation • SwaggerUI integration                                               |
| **Interview Focus**     | Minimal API tradeoffs • When to use vs controllers • Organizing larger minimal APIs                                             |

## 10.2 Top-Level Statements & File-Scoped Types

| Aspect                | Details                                                                                                            |
| --------------------- | ------------------------------------------------------------------------------------------------------------------ |
| **Topic**             | Simplified C# Syntax                                                                                               |
| **Description**       | Reduce boilerplate. Top-level statements eliminate `Program.cs` ceremony. File-scoped types improve encapsulation. |
| **Key Concepts**      | Top-level statements (no Main method needed) • File-scoped types (`file class`) • Global using statements          |
| **Skill Level**       | Beginner → Intermediate                                                                                            |
| **Priority**          | **MUST-KNOW**                                                                                                      |
| **Before**            |                                                                                                                    |
|                       | `class Program {`                                                                                                  |
|                       | `    static async Task Main(string[] args) {`                                                                      |
|                       | `        var app = WebApplication.CreateBuilder(args).Build();`                                                    |
|                       | `        app.Run();`                                                                                               |
|                       | `    }`                                                                                                            |
|                       | `}`                                                                                                                |
| **After**             |                                                                                                                    |
|                       | `var app = WebApplication.CreateBuilder(args).Build();`                                                            |
|                       | `app.Run();`                                                                                                       |
| **File-Scoped Types** | `file class InternalHelper` prevents accidental use from other files • Improves encapsulation                      |
| **Global Usings**     | `GlobalUsings.cs` with `global using System;` imports in all files                                                 |
| **Interview Focus**   | Trade-offs of reducing ceremony • File-scoped types encapsulation                                                  |

## 10.3 Records & Immutable Data

| Aspect                   | Details                                                                                                                   |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------- |
| **Topic**                | Records, Positional Parameters, With Expression                                                                           |
| **Description**          | Immutable, value-semantics types. Concise syntax for DTOs, value objects. `with` expression for non-destructive mutation. |
| **Key Concepts**         | Record declaration • Positional parameters • Value equality • `init` properties • `with` expression • Sealed records      |
| **Skill Level**          | Intermediate                                                                                                              |
| **Priority**             | **MUST-KNOW**                                                                                                             |
| **Example**              |                                                                                                                           |
|                          | `public record User(int Id, string Name, string Email);`                                                                  |
|                          | `var user = new User(1, "John", "john@test.com");`                                                                        |
|                          | `var updated = user with { Name = "Jane" };` // Creates new instance                                                      |
| **Records vs Classes**   | Immutable by default, value equality, concise • Use for DTOs, view models, domain value objects                           |
| **Init-Only Properties** | `public string Name { get; init; }` set only during initialization                                                        |
| **Record Structs**       | Value type (stack allocated) records. Lightweight.                                                                        |
| **Interview Focus**      | When to use records vs classes • Immutability benefits • with expression understanding                                    |

## 10.4 Pattern Matching Enhancements

| Aspect              | Details                                                                                                                    |
| ------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| **Topic**           | Advanced Pattern Matching, Type, Relational, Property Patterns                                                             |
| **Description**     | Powerful pattern matching beyond switch. Type patterns, property patterns, relational patterns. Cleaner code.              |
| **Key Concepts**    | Type patterns • Property patterns • Relational patterns (>, <, ==, etc.) • List patterns • Logical patterns (and, or, not) |
| **Skill Level**     | Intermediate → Advanced                                                                                                    |
| **Priority**        | **SHOULD-KNOW**                                                                                                            |
| **Examples**        |                                                                                                                            |
|                     | `// Property pattern`                                                                                                      |
|                     | `if (user is { Role: "Admin", IsActive: true }) { ... }`                                                                   |
|                     | `// Type pattern`                                                                                                          |
|                     | `if (user is Employee { Department: "Sales" }) { ... }`                                                                    |
|                     | `// Relational pattern`                                                                                                    |
|                     | `if (age is >= 18 and < 65) { ... }`                                                                                       |
|                     | `// List pattern (C# 11)`                                                                                                  |
|                     | `if (numbers is [first, .. middle, last]) { ... }`                                                                         |
| **Benefits**        | Concise, readable, compile-time checked • Reduces boilerplate                                                              |
| **Interview Focus** | Pattern matching use cases • Extracting complex data structures                                                            |

## 10.5 Source Generators & AOT Compilation

| Aspect                | Details                                                                                                                                                      |
| --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Topic**             | Compile-Time Code Generation, Native AOT                                                                                                                     |
| **Description**       | Generate code at compile-time. Eliminate reflection overhead. Smaller binaries, faster startup. Native AOT for C# → native executable.                       |
| **Key Concepts**      | Source generators • Compile-time vs runtime • Native AOT (no JIT, full ahead-of-time compilation) • Trimming • ReadyToRun (R2R)                              |
| **Skill Level**       | Advanced                                                                                                                                                     |
| **Priority**          | **NICE-TO-KNOW** → **SHOULD-KNOW** for high-performance systems                                                                                              |
| **Source Generators** | Custom analyzers generating code • JSON source generator (compile-time JSON serialization) • DI source generator (compile-time resolution)                   |
| **Native AOT**        | `dotnet publish -c Release /p:PublishAot=true` • No JIT startup overhead • Smaller memory footprint • Challenges: reflection limitations, trimming awareness |
| **Trimming**          | Removing unused code for smaller binaries • Requires framework/library support • Analyzers help identify issues                                              |
| **Use Cases**         | Containerized microservices, serverless (AWS Lambda, Azure Functions), command-line tools                                                                    |
| **Limitations**       | Reflection restrictions • Limited dynamic loading • Libraries must be AOT-compatible                                                                         |
| **Interview Focus**   | AOT compilation benefits/tradeoffs • When AOT justified • Trimming awareness                                                                                 |

## 10.6 LINQ Improvements & Chaining

| Aspect              | Details                                                                                                |
| ------------------- | ------------------------------------------------------------------------------------------------------ |
| **Topic**           | LINQ Enhancements, Queryable Improvements                                                              |
| **Description**     | New LINQ methods: Chunk, Index, etc. Improved query composition.                                       |
| **Key Concepts**    | `Chunk(size)` • `Index()` • `Take(range)` • `DistinctBy()`, `UnionBy()`, `ExceptBy()`, `IntersectBy()` |
| **Skill Level**     | Intermediate                                                                                           |
| **Priority**        | **NICE-TO-KNOW**                                                                                       |
| **.NET 8+ Methods** |                                                                                                        |
|                     | `var chunked = items.Chunk(10);` // Split into groups of 10                                            |
|                     | `var indexed = items.Index();` // (index, item) tuples                                                 |
|                     | `var distinct = users.DistinctBy(u => u.Email);` // By property                                        |
| **Interview Focus** | New LINQ method applications • Query optimization                                                      |

---

# Learning Path Recommendations

## For Beginners

1. **C# Fundamentals** (1-2 weeks)
   - Data types, OOP basics, control flow
2. **ASP.NET Core Web API** (2-3 weeks)
   - Controllers, routing, basic middleware
3. **Data Access with EF Core** (2-3 weeks)
   - DbContext, LINQ, migrations
4. **Testing** (1-2 weeks)
   - Unit tests, mocking basics

## For Intermediate Developers

1. **Advanced C#** (1-2 weeks)
   - LINQ, async/await, generics, delegates
2. **Architecture Patterns** (2-3 weeks)
   - SOLID, clean architecture, design patterns
3. **Authentication & Authorization** (1-2 weeks)
   - JWT, OAuth2, claims-based policies
4. **Performance Optimization** (1-2 weeks)
   - Async optimization, caching, profiling
5. **Cloud & DevOps** (2-3 weeks)
   - Azure services, Docker, CI/CD

## For Senior Developers / Architects

1. **Domain-Driven Design** (2-3 weeks)
2. **CQRS & Event Sourcing** (2-3 weeks)
3. **Microservices Architecture** (3-4 weeks)
4. **Advanced Performance** (2-3 weeks)
5. **Security Deep Dive** (2-3 weeks)

---

# Key Interview Preparation Topics

## Code Design Questions

- Explain SOLID principles with examples
- Design a service for [common scenario]
- Refactor this code for testability
- Identify design patterns in code

## Performance Questions

- Optimize this N+1 query
- Reduce allocations in this code path
- Design caching strategy for scenario
- Explain async/await execution model

## Architecture Questions

- When to use microservices vs monolith
- Service boundaries in distributed system
- How would you structure large application
- Database strategy for scaled system

## Practical Coding

- Implement minimal API endpoint
- Write unit tests with mocking
- Design entity model for scenario
- Create middleware for cross-cutting concern

---

# Continuous Learning Resources

## Official Documentation

- docs.microsoft.com/en-us/dotnet
- Microsoft Learn modules (free, hands-on)

## Books

- "C# Player's Guide" by RB Whitaker
- "Clean Code" by Robert C. Martin
- "Domain-Driven Design" by Eric Evans
- "Building Microservices" by Sam Newman

## Online Communities

- Microsoft Q&A
- Stack Overflow
- .NET Foundation Discussions
- GitHub Discussions

## Practice

- LeetCode / HackerRank (.NET focused)
- Open-source contribution
- Build real projects
- Code reviews

---

## Legend

| Symbol           | Meaning                                                                |
| ---------------- | ---------------------------------------------------------------------- |
| **MUST-KNOW**    | Critical for professional development. Expected in interviews.         |
| **SHOULD-KNOW**  | Important for senior roles and architects. Strong interview advantage. |
| **NICE-TO-KNOW** | Valuable context, specialized use cases.                               |
| **Skill Level**  | Beginner → Intermediate → Advanced progression                         |

---

**Last Updated:** February 2025 | **Target Framework:** .NET 8+

This guide is your roadmap from beginner to senior .NET developer. Follow the prioritization, refer to interview focus areas, and build real projects to solidify learning. Remember: **depth over breadth** — master fundamentals before advanced topics.
