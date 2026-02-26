using MagShared;
using Microsoft.AspNetCore.Mvc;

namespace VagProd.WebApi.Controllers;

[ApiController]
[Route("api-[controller]")]
public abstract class ApplicationController : ControllerBase
{
    public override OkObjectResult Ok(object? value)
    {
        var envelope = Envelope.Ok(value);
        return new(envelope);
    }

    public override BadRequestObjectResult BadRequest(object errorMy)
    {
        var envelope = Envelope.Error(errorMy as ErrorMy);
        return new(envelope);
    }
}