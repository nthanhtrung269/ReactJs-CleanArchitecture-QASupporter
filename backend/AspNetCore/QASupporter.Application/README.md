# Application Layer

- This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

## Command and Query Responsibility Segregation (CQRS) pattern

- CQRS separates reads and writes into different models, using commands to update data, and queries to read data.
- Commands should be task based, rather than data centric. ("Book hotel room", not "set ReservationStatus to Reserved").
- Commands may be placed on a queue for asynchronous processing, rather than being processed synchronously.
- Queries never modify the database. A query returns a DTO that does not encapsulate any domain knowledge.

## Documents

- [Command and Query Responsibility Segregation (CQRS) pattern] (https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
