namespace UnitConversion.Api.Converters;
public sealed class LengthConverter : IUnitConverter
{
    private static readonly IReadOnlyDictionary<string, double> Factors =
        new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            ["meter"] = 1d, ["metre"] = 1d, ["kilometer"] = 1000d, ["kilometre"] = 1000d,
            ["centimeter"] = 0.01d, ["centimetre"] = 0.01d, ["millimeter"] = 0.001d,
            ["millimetre"] = 0.001d, ["inch"] = 0.0254d, ["foot"] = 0.3048d,
            ["yard"] = 0.9144d, ["mile"] = 1609.344d
        };
    public bool Supports(string unit) => !string.IsNullOrWhiteSpace(unit) && Factors.ContainsKey(unit.Trim());
    public double Convert(double value, string fromUnit, string toUnit)
        => value * Factors[fromUnit.Trim()] / Factors[toUnit.Trim()];
}
