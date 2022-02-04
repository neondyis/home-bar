using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

public class BaseController :  ControllerBase
{
    protected BarContext DbContext => (BarContext)HttpContext.RequestServices.GetService(typeof(BarContext))!;
}