# BoardGameClub API

A RESTful API built for managing a board game club ecosystem.  
This project provides backend services for handling members, board games, events, sessions, collections, and club-related operations.

Designed with scalability and maintainability in mind using ASP.NET and modern backend development practices.

## Features

- Member management
- Board game catalog integration
- Event and game session tracking
- Collection and inventory management
- Authentication and authorization
- RESTful API architecture
- Database-driven persistence
- External integration support (e.g. BoardGameGeek API)

## Tech Stack

- .NET Core 10
- Entity Framework
- SQL Server
- REST API
- LINQ
- Dependency Injection
- Git & GitHub
- Azure

## Purpose

The goal of this project is to provide a centralized backend system for a board game club where members can:

- Discover and manage games
- Organize play sessions and events
- Track collections and participation
- Integrate external board game data
- Support future web or mobile applications

## Status

Currently under active development.


## Scaffolding Tool
```
dotnet ef dbcontext scaffold "Server=localhost;Database=fbgcdb;User Id=user;Password=P@ssw0rd;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --project BoardGameClub.Infrastructure --startup-project BoardGameClub.Api --output-dir Persistence/Scaffolded --context AppDbContext --force --no-onconfiguring
```

# System Architecture
```
BoardGameClubApi/
│
├── src/
│   │
│   ├── BoardGameClub.Api/              # 🌐 API Layer
│   │   ├── Controllers/
│   │   ├── Middlewares/
│   │   ├── Extensions/
│   │   ├── Program.cs
│   │   └── appsettings.json
│   │
│   ├── BoardGameClub.Application/      # ⚙️ Use Cases (core logic)
│   │   ├── Features/
│   │   │   ├── Members/
│   │   │   │   ├── CreateMember/
│   │   │   │   ├── GetMembers/
│   │   │   │   └── UpdateMember/
│   │   │   │
│   │   │   ├── Games/
│   │   │   │   ├── AddGame/
│   │   │   │   ├── GetGames/
│   │   │   │   └── UpdateGame/
│   │   │   │
│   │   │   ├── Sessions/
│   │   │   │   ├── CreateSession/
│   │   │   │   ├── JoinSession/
│   │   │   │   └── GetSessions/
│   │   │
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   ├── Validators/
│   │   └── Common/
│   │
│   ├── BoardGameClub.Domain/           # 🧠 Core business rules
│   │   ├── Entities/
│   │   │   ├── Member.cs
│   │   │   ├── BoardGame.cs
│   │   │   ├── GameSession.cs
│   │   │   └── Attendance.cs
│   │   │
│   │   ├── Enums/
│   │   │   ├── GameCategory.cs
│   │   │   └── SessionStatus.cs
│   │   │
│   │   ├── ValueObjects/
│   │   └── Common/
│   │
│   ├── BoardGameClub.Infrastructure/   # 💾 DB + external services
│   │   ├── Persistence/
│   │   │   ├── AppDbContext.cs
│   │   │   ├── Configurations/
│   │   │   └── Migrations/
│   │   │
│   │   ├── Repositories/
│   │   ├── Services/
│   │   └── DependencyInjection/
│   │
│   └── BoardGameClub.Shared/           # 🔁 shared helpers (optional)
│       ├── Constants/
│       ├── Helpers/
│       └── Results/
│
├── tests/
│   ├── BoardGameClub.UnitTests/
│   └── BoardGameClub.IntegrationTests/
│
└── BoardGameClub.sln
```


## Architecture Flow
```
Controller (API)
    ↓
CreateSessionCommand (Application)
    ↓
CreateSessionHandler (Application logic)
    ↓
Domain Entities (GameSession, Member, Game)
    ↓
Repositories (Interfaces in Application)
    ↓
Infrastructure (EF Core / DB)
```

## Key Takeaways
```
📌 Application/Features contains:
Commands (CreateSessionCommand)
Queries (GetSessionsQuery)
Handlers (business orchestration)
Validators
DTOs
Interfaces (repositories/services contracts)
📌 Domain contains:
GameSession rules
Member rules
Enums like SessionStatus
Value objects (if needed)
📌 Infrastructure contains:
EF Core DbContext
Repository implementations
External APIs
```
