# You too, can Kanban!

A Trello clone, written as an ASP.NET Restful API.
Designed as a "Breakable Toy" and to serve as an example of patterns, practices and techniques I've picked up.
There's a lot of boilerplate here, so it might not be your cup-of-tea. However it runs well, is resilient, and is wicked-fast on the backend :)

## Features

- .Net 8 ASP.Net Rest API
  - Minimal API Endpoints, with OpenAPI definitions
  - Mediator Pattern with Command Query Seperation
  - N-Tier Layered Architecture
  - Advanced use of Generics and Abstractions, for truly DRY Implementations
  - Unit of Work Pattern, with implicit transactions
  - Defensive Programming Patterns
  - Docker Support
- .Net 8 Blazor WASM Client
  - APi Clients via Refit
- Shared Domain Model
- Architecture Tests (Coming Soon!)
- Integration Tests (Coming Soon!)

## Instructions

- TODO...

### Migrations

- Go to PMC in VisualStudio
  - ```add-migration InitialMigration```
  - ```update-database```
