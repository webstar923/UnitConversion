using Microsoft.AspNetCore.Mvc;
using UnitConversion.Api.Models;
using UnitConversion.Api.Services;
namespace UnitConversion.Api.Controllers;
[ApiController]
[Route("api/conversions")]
public sealed class ConversionsController(IUnitConversionService service) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<ConversionResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public ActionResult<ConversionResponse> Convert([FromBody] ConversionRequest request)
    {
        var result = service.Convert(request.Value, request.FromUnit, request.ToUnit);
        return Ok(new ConversionResponse(request.Value, request.FromUnit, request.ToUnit, result));
    }
}
