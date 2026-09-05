# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-09-05

### Added
- TS01: Retrieve Greeting Count via GET Request.
- TS02: Create Greeting via POST Request, personalized or anonymous.
- `IGreetingCounter` domain service (thread-safe, `Interlocked`/`Volatile`-backed) tracking personalized and anonymous greeting counts separately, plus their total.
- `Developer` entity with UUID v7 identifiers and a `PersonName` value object that's never missing (`PersonName.Anonymous` stands in when one isn't given).
- Length validation on `GreetDeveloperRequest` (`[StringLength]`); a missing name is anonymous, not an error.
- Requirement Traceability Matrix in `docs/user-stories.md`, Architecture Decision Records in `docs/adrs.md`.