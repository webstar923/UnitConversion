using System.ComponentModel.DataAnnotations;
namespace UnitConversion.Api.Models;
public sealed record ConversionRequest(
    [property: Required] double Value,
    [property: Required, MinLength(1)] string FromUnit,
    [property: Required, MinLength(1)] string ToUnit);
