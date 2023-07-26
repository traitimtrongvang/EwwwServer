using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ControllerBase: Microsoft.AspNetCore.Mvc.ControllerBase
{
    
}