using Xunit;
using UnitConversion.Api.Converters;
namespace UnitConversion.Api.Tests;
public sealed class ConverterTests
{
    [Theory]
    [InlineData(1, "meter", "foot", 3.280839895013123)]
    [InlineData(1000, "meter", "kilometer", 1)]
    public void Length(double value, string from, string to, double expected)
        => Assert.Equal(expected, new LengthConverter().Convert(value, from, to), 10);

    [Theory]
    [InlineData(1, "kilogram", "pound", 2.2046226218487757)]
    [InlineData(1000, "gram", "kilogram", 1)]
    public void Mass(double value, string from, string to, double expected)
        => Assert.Equal(expected, new MassConverter().Convert(value, from, to), 10);

    [Theory]
    [InlineData(0, "celsius", "fahrenheit", 32)]
    [InlineData(100, "celsius", "fahrenheit", 212)]
    [InlineData(32, "fahrenheit", "celsius", 0)]
    [InlineData(0, "celsius", "kelvin", 273.15)]
    public void Temperature(double value, string from, string to, double expected)
        => Assert.Equal(expected, new TemperatureConverter().Convert(value, from, to), 10);
}
