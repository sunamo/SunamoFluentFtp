# SunamoFluentFtp

## Short description

Obal nad knihovnou FluentFtp pro práci s FTP.


Wrapper around FluentFtp library

## Overview

SunamoFluentFtp is part of the Sunamo package ecosystem, providing modular, platform-independent utilities for .NET development.

## Main Components

### Key Classes

- **FluentFtpAdds**
- **FluentFtpWrapper**
- **FluentFtpTest**
- **DirectoriesToDeleteFluentFtp**
- **PathSelectorFluentFtp**

### Key Methods

- `TestBasicFunctionality()`
- `FluentFtp()`
- `setRemoteHost()`
- `getRemoteHost()`
- `setRemotePort()`
- `getRemotePort()`
- `setRemoteUser()`
- `DivideToTokens()`
- `RemoveLastTokenForce()`
- `RemoveLastToken()`

## Installation

```bash
dotnet add package SunamoFluentFtp
```

## Dependencies

- **FluentFTP** (v52.1.0)
- **Microsoft.Extensions.Logging.Abstractions** (v9.0.3)

## Package Information

- **Package Name**: SunamoFluentFtp
- **Version**: 25.3.29.1
- **Target Framework**: net9.0
- **Category**: Platform-Independent NuGet Package
- **Source Files**: 13

## Related Packages

This package is part of the Sunamo package ecosystem. For more information about related packages, visit the main repository.

## License

See the repository root for license information.

<!-- sunamo:test-coverage:start -->
## Test coverage

| Metric | Value |
|---|---|
| Method | static |
| Test projects | 1 |
| Public types referenced by tests | 0/8 (0.0 %) |
| Public methods referenced by tests | 0/35 (0.0 %) |
| Line coverage | n/a |
| Branch coverage | n/a |
| Generated (UTC) | 2026-11-22 21:24 |

<!-- sunamo:test-coverage:data {"package":"SunamoFluentFtp","container":"pinp","testProjects":1,"publicTypes":8,"typesReferencedByTests":0,"publicMethods":35,"methodsReferencedByTests":0,"lineRate":null,"branchRate":null,"method":"static","generatedUtc":"2026-11-22 21:24"} -->
<!-- sunamo:test-coverage:end -->
