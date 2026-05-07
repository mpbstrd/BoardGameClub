# BoardGameClub API
- An API made for Friday Board Game Club


## Scaffolding Tool
```
dotnet ef dbcontext scaffold "Server=localhost;Database=bgcdb;User Id=user;Password=P@ssw0rd;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --project BoardGameClub.Infrastructure --startup-project BoardGameClub.Api --output-dir Persistence/Scaffolded --context AppDbContext --force --no-onconfiguring
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
