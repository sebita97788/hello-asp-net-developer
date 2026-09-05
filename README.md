# Hello ASP.NET Developer (`hello-asp-net-developer`)

[![.NET](https://img.shields.io/badge/.NET-10-purple.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE.md)

`hello-asp-net-developer` is a sample ASP.NET Core Minimal API illustrating Object-Oriented Programming and Domain-Driven Design in a single bounded context (`Profiles`): a greeting endpoint that works for both a named and an anonymous developer.

---

## Technical Stack & Modern Features

- **Runtime & Framework**: .NET 10.0 (C# 14.0), ASP.NET Core Minimal APIs
- **C# 14 & .NET 10 Features**:
    - **`field` Keyword**: property validation and null-safe fallback without an explicit private backing field (`PersonName`).
    - **Struct Parameterless Constructor Safety**: `PersonName`, a `readonly record struct`, throws `InvalidOperationException` from `new PersonName()`.
    - **UUIDv7 Identifiers**: time-ordered identifiers via `Guid.CreateVersion7()` (`Developer.Id`), even for an anonymous developer.
    - **Minimal API Validation**: `builder.Services.AddValidation()`, a .NET 10 built-in, no separate validation package.
    - **Modern Throw Helpers**: `ArgumentException.ThrowIfNullOrWhiteSpace`, not hand-written null checks.

---

## Solution Structure

```text
hello-asp-net-developer/
├── Acme.Hello.Platform/                    # Main API project
│   └── Profiles/                           # Profiles Bounded Context
│       ├── Domain/
│       │   ├── Model/
│       │   │   ├── Entities/               # Developer
│       │   │   └── ValueObjects/           # PersonName
│       │   └── Services/                   # IGreetingCounter, GreetingCounter (Internal)
│       └── Interfaces/Rest/
│           ├── Assemblers/                 # DeveloperAssembler, GreetDeveloperAssembler
│           ├── Resources/                  # GreetDeveloperRequest/Response, GetGreetingCountResponse
│           └── GreetingEndpoints.cs        # Maps GET/POST /api/v1/greetings
├── docs/                                   # Architecture & requirements documentation
│   ├── class-diagram.puml                  # PlantUML domain model class diagram
│   └── user-stories.md                     # User stories (TS01-TS02) & Requirements Traceability Matrix
├── CHANGELOG.md                            # Project release notes & version history
├── LICENSE.md                              # Project license
└── README.md                               # Project overview & guide
```

---

## Bounded Contexts & Domain Model

### `Acme.Hello.Platform.Profiles`
- **`Developer`** (*Entity*): identity (`Guid`, UUID v7) plus a `PersonName` that's never missing; a developer who doesn't reveal one gets the well-known `PersonName.Anonymous` instead.
- **`PersonName`** (*Value Object*): validated `readonly record struct`; even its well-known `Anonymous` placeholder is a fully validated instance, never a blank or unvalidated one.
- **`IGreetingCounter`** (*Domain Service*): thread-safe, personalized and anonymous greetings tracked separately, never collapsed into a single total.

---

## Key Domain Rules & Design Invariants

- **Anonymous is a value, not an absence**: `PersonName` always validates and throws when constructed, `Anonymous` included; "no name" is modeled as `Developer.Name` holding that well-known `PersonName`, never as `null`.
- **Anonymous greetings are legitimate, not rejected**: a missing or blank name produces a `201` anonymous greeting; a name that is present but too long is still rejected with a `400`.
- **Every developer has a real identity**: `Guid.CreateVersion7()` runs for every `Developer`, personalized or anonymous, never a nullable ID.
- **Personalized and anonymous counts tracked separately**: `TotalCount` is always computed as their sum, never its own field, so it can't drift out of sync.
- **Thread-safe counting**: `Interlocked`/`Volatile` on each backing field, not a `lock`.

---

## Project Documentation

| Document | Description |
| :--- | :--- |
| [**User Stories & RTM**](docs/user-stories.md) | User stories (TS01-TS02) and Requirements Traceability Matrix. |
| [**Class Diagram**](docs/class-diagram.puml) | PlantUML class diagram of the `Profiles` bounded context. |
| [**Changelog**](CHANGELOG.md) | Version history and release notes. |
| [**License**](LICENSE.md) | Project licensing information (MIT). |

---

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download) (or later)

### Build the Solution
```bash
dotnet build
```

### Run the Application
```bash
dotnet run --project Acme.Hello.Platform
```

### Access the API
Port `5195` below is this project's own; check `Properties/launchSettings.json` for yours if it's different.
- Scalar UI: `http://localhost:5195/scalar/v1`
- Or send requests directly, for example:
  ```bash
  curl -X POST http://localhost:5195/api/v1/greetings \
       -H "Content-Type: application/json" \
       -d '{"firstName": "John", "lastName": "Doe"}'
  ```