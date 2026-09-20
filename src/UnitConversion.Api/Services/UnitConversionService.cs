using UnitConversion.Api.Converters;
using UnitConversion.Api.Exceptions;
namespace UnitConversion.Api.Services;
public sealed class UnitConversionService(IEnumerable<IUnitConverter> converters) : IUnitConversionService
{
    public double Convert(double value, string fromUnit, string toUnit)
    {
        if (string.IsNullOrWhiteSpace(fromUnit) || string.IsNullOrWhiteSpace(toUnit))
            throw new UnsupportedConversionException("Both fromUnit and toUnit are required.");
        var converter = converters.FirstOrDefault(c => c.Supports(fromUnit) && c.Supports(toUnit));
        if (converter is null)
            throw new UnsupportedConversionException($"Conversion from '{fromUnit}' to '{toUnit}' is not supported.");
        return converter.Convert(value, fromUnit, toUnit);
    }
}
