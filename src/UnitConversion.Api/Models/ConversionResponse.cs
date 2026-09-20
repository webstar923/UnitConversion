namespace UnitConversion.Api.Models;
public sealed record ConversionResponse(double Value, string FromUnit, string ToUnit, double Result);
