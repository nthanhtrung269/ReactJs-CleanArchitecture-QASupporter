# WebApi Layer

- This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.

## Documents

- [Command and Query Responsibility Segregation (CQRS) pattern] (https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
