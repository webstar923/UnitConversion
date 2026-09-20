namespace UnitConversion.Api.Converters;
public sealed class TemperatureConverter : IUnitConverter
{
    private static readonly HashSet<string> Units = new(StringComparer.OrdinalIgnoreCase) { "celsius", "fahrenheit", "kelvin" };
    public bool Supports(string unit) => !string.IsNullOrWhiteSpace(unit) && Units.Contains(unit.Trim());
    public double Convert(double value, string fromUnit, string toUnit)
    {
        var celsius = fromUnit.Trim().ToLowerInvariant() switch
        {
            "celsius" => value,
            "fahrenheit" => (value - 32d) * 5d / 9d,
            "kelvin" => value - 273.15d,
            _ => throw new ArgumentOutOfRangeException(nameof(fromUnit))
        };
        return toUnit.Trim().ToLowerInvariant() switch
        {
            "celsius" => celsius,
            "fahrenheit" => celsius * 9d / 5d + 32d,
            "kelvin" => celsius + 273.15d,
            _ => throw new ArgumentOutOfRangeException(nameof(toUnit))
        };
    }
}
