# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a minimal ASP.NET Core Web API project for transaction fee calculation. The application provides a REST API endpoint for calculating fees based on transaction properties.

## Architecture

The codebase follows a clean, layered architecture:

- **Controllers/**: API endpoints (FeeController handles POST /api/fees/calculate)
- **Services/**: Business logic layer (IFeeCalculator interface and FeeCalculator implementation)
- **Domain/**: Domain models (Transaction input, FeeResult output)
- **Program.cs**: Application entry point with minimal hosting setup

The FeeCalculator service is registered with scoped lifetime in the DI container and injected into the FeeController. The current implementation returns a zero fee for all transactions.

## Development Commands

This project uses top-level statements and does not have a .csproj or .sln file in the root. You'll need to work with the .NET CLI directly:

**Run the application:**
```bash
dotnet run
```

**Build the application:**
```bash
dotnet build
```

**Run tests (when test project exists):**
```bash
dotnet test
```
