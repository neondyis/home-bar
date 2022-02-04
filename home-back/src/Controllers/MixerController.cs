using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

public class MixerController :  BaseController
{
    [HttpGet]
    public List<Mixer> Get() => DbContext.Mixers.ToList();
}