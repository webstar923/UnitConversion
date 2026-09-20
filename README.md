# Unit Conversion API

A small ASP.NET Core REST API for converting numerical values between units of measurement. It supports length, temperature, and mass and is structured so additional conversion categories and units can be added without putting conversion logic in the HTTP controller.

## Requirements

- .NET 10 SDK

## Run locally

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/UnitConversion.Api
```

The console output shows the local HTTP/HTTPS address. In Development, the OpenAPI document is available at `/openapi/v1.json`.

## API

`POST /api/conversions`

Example request:

```json
{
  "value": 100,
  "fromUnit": "meter",
  "toUnit": "foot"
}
```

Example response:

```json
{
  "value": 100,
  "fromUnit": "meter",
  "toUnit": "foot",
  "result": 328.0839895013123
}
```

Unsupported units or cross-category conversions return HTTP 400 with Problem Details.

## Supported units

- Length: meter/metre, kilometer/kilometre, centimeter/centimetre, millimeter/millimetre, inch, foot, yard, mile
- Mass: kilogram, gram, milligram, pound, ounce, stone
- Temperature: celsius, fahrenheit, kelvin

## Design decisions

- Controllers only handle HTTP concerns; conversion rules live behind `IUnitConversionService` and `IUnitConverter`.
- Length and mass convert through a category base unit, avoiding a separate formula for every unit pair.
- Temperature has a dedicated converter because temperature conversions require both scale and offset.
- Converter implementations are registered through dependency injection. Adding a new category means adding another `IUnitConverter` rather than modifying the controller.
- Unit data is intentionally hardcoded for this version. For hundreds of units, the factor/metadata definitions could move to configuration or persistent storage while keeping the service contract stable.
- `double` is used because this is a general measurement API. A domain requiring strict decimal precision could choose `decimal` instead.

## Project structure

- `src/UnitConversion.Api` — Web API, service, converters, models, middleware
- `tests/UnitConversion.Api.Tests` — unit tests for the conversion rules
