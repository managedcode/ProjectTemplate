# ProjectTemplate

A .NET 9 project template with [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/) orchestration, including a sample API with tests and automated CI/CD pipelines.

## Features

- ✨ **ASP.NET Core Web API** - Minimal API with weather forecast endpoint
- 🚀 **.NET Aspire** - Modern cloud-native application orchestration
- 🧪 **xUnit Tests** - Integration tests using WebApplicationFactory
- 📦 **Service Defaults** - Shared telemetry, service discovery, and resilience patterns
- 🔄 **GitHub Actions** - Automated CI/CD pipelines for testing, security analysis, and releases
- 📊 **Code Coverage** - Integrated with Codecov for coverage tracking
- 🔒 **CodeQL Analysis** - Automated security scanning on every push

## Project Structure

```
ProjectTemplate/
├── src/
│   ├── ProjectTemplate.Api/              # ASP.NET Core Web API
│   ├── ProjectTemplate.AppHost/          # Aspire orchestration host
│   └── ProjectTemplate.ServiceDefaults/  # Shared configuration and services
├── tests/
│   └── ProjectTemplate.Tests/            # Integration tests
├── .github/
│   └── workflows/
│       ├── ci.yml                        # Build and test on PR
│       ├── codeql-analysis.yml           # Security analysis
│       └── release.yml                   # Release and publish to NuGet
└── Directory.Build.props                 # Shared build properties and versioning
```

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (for Aspire Dashboard)

### Installation

1. Install the .NET Aspire workload:
   ```bash
   dotnet workload install aspire
   ```

2. Clone the repository:
   ```bash
   git clone https://github.com/managedcode/ProjectTemplate.git
   cd ProjectTemplate
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

### Running the Application

#### Using .NET Aspire AppHost (Recommended)

This will start the API and open the Aspire Dashboard:

```bash
dotnet run --project src/ProjectTemplate.AppHost
```

The Aspire Dashboard will be available at the URL shown in the console output (typically `http://localhost:15888`).

#### Running the API Directly

```bash
dotnet run --project src/ProjectTemplate.Api
```

The API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`

### Running Tests

```bash
dotnet test
```

### Building

```bash
dotnet build --configuration Release
```

## API Endpoints

### Weather Forecast
- **GET** `/weatherforecast` - Returns a 5-day weather forecast

### Health & Metrics (via ServiceDefaults)
- **GET** `/health` - Health check endpoint
- **GET** `/alive` - Liveness probe
- **GET** `/metrics` - Prometheus metrics

## Development

### Adding a New Service

1. Create a new project in the `src` folder
2. Reference `ProjectTemplate.ServiceDefaults` to get shared configurations
3. Add the project to the AppHost in `src/ProjectTemplate.AppHost/Program.cs`:

```csharp
var myService = builder.AddProject<Projects.MyService>("myservice");
```

### Running Tests in Development

The project includes two types of tests:

1. **WebApplicationFactory Tests** - Run in any environment (CI/CD friendly)
2. **Aspire Integration Tests** - Require the DCP (Development Control Plane), skipped in CI

## CI/CD Pipelines

### CI Workflow (`.github/workflows/ci.yml`)
Runs on every pull request and push to main:
- Builds the solution
- Runs all tests
- Collects code coverage
- Uploads coverage to Codecov

### CodeQL Workflow (`.github/workflows/codeql-analysis.yml`)
Runs on:
- Every push to main
- Every pull request
- Weekly schedule (Monday at midnight)

Performs automated security scanning to detect vulnerabilities.

### Release Workflow (`.github/workflows/release.yml`)
Runs on push to main:
- Builds and tests the solution
- Packs NuGet packages
- Publishes to NuGet.org (requires `NUGET_API_KEY` secret)
- Creates GitHub release with auto-generated release notes
- Tags the release

## Configuration

### Versioning

Version is managed in `Directory.Build.props`:

```xml
<Version>1.0.0</Version>
```

Update this version to release new versions to NuGet.

### GitHub Secrets

To enable the full CI/CD pipeline, configure these secrets in your GitHub repository:

- `NUGET_API_KEY` - API key for publishing to NuGet.org
- `CODECOV_TOKEN` - Token for uploading coverage to Codecov (optional)

## Technologies

- [.NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/)
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [xUnit](https://xunit.net/)
- [OpenTelemetry](https://opentelemetry.io/)
- [GitHub Actions](https://github.com/features/actions)

## License

MIT

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.