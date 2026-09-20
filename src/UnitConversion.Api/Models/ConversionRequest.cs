using System.ComponentModel.DataAnnotations;

namespace UnitConversion.Api.Models;

public sealed class ConversionRequest
{
    public double Value { get; init; }

    [Required]
    public string FromUnit { get; init; } = string.Empty;

    [Required]
    public string ToUnit { get; init; } = string.Empty;
}