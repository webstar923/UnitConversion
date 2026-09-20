using UnitConversion.Api.Converters;
using UnitConversion.Api.Middleware;
using UnitConversion.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IUnitConverter, LengthConverter>();
builder.Services.AddSingleton<IUnitConverter, MassConverter>();
builder.Services.AddSingleton<IUnitConverter, TemperatureConverter>();
builder.Services.AddScoped<IUnitConversionService, UnitConversionService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
if (app.Environment.IsDevelopment()) app.MapOpenApi();
app.MapControllers();
app.Run();

public partial class Program { }
