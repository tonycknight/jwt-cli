# jwt-cli

[![Build & Release](https://github.com/tonycknight/jwt-cli/actions/workflows/build.yml/badge.svg)](https://github.com/tonycknight/jwt-cli/actions/workflows/build.yml)

![Nuget](https://img.shields.io/nuget/v/jwt-cli)

A `dotnet tool` for various development tasks.

---

# Getting Started

## Dependenices

You'll need the [.Net 6 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) installed.

## Installation

``jwt-cli`` is available from [Nuget](https://www.nuget.org/packages/jwt-cli/):

```
dotnet tool install jwt-cli -g
```

---

# How to use

## Help:

```
jwt -?
```


## Decode JWT

```
jwt <jwt>
```

Where:

`<jwt>` is the base-64 encoded JWT token to decode


Example:

```
jwt "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"



Algorithm    HS256
Claim [iat]  1516239022
Claim [name] John Doe
Claim [sub]  1234567890
Issued at    2018-01-18 01:30:22
Subject      1234567890
Valid from   0001-01-01 00:00:00
Valid to     0001-01-01 00:00:00

```

---

## Copyright and notices

(c) Tony Knight 2023.

