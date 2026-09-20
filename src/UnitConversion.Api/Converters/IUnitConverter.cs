namespace UnitConversion.Api.Converters;
public interface IUnitConverter
{
    bool Supports(string unit);
    double Convert(double value, string fromUnit, string toUnit);
}
