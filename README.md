# BoardGameClub API
- An API made for Friday Board Game Club

#

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
