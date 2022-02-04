using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class MeasurementController :  BaseController
{
    [HttpGet]
    public List<Measurement> Get() => DbContext.Measurements.ToList();
}