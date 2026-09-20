namespace UnitConversion.Api.Converters;
public sealed class MassConverter : IUnitConverter
{
    private static readonly IReadOnlyDictionary<string, double> Factors =
        new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            ["kilogram"] = 1d, ["gram"] = 0.001d, ["milligram"] = 0.000001d,
            ["pound"] = 0.45359237d, ["ounce"] = 0.028349523125d, ["stone"] = 6.35029318d
        };
    public bool Supports(string unit) => !string.IsNullOrWhiteSpace(unit) && Factors.ContainsKey(unit.Trim());
    public double Convert(double value, string fromUnit, string toUnit)
        => value * Factors[fromUnit.Trim()] / Factors[toUnit.Trim()];
}
