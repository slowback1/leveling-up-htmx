using LevelingUp.HTMX.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LevelingUp.HTMX.Controllers;

[Route("Demo")]
public class DemoController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("GetTime")]
    public IActionResult GetTime()
    {
        return Ok(DateTime.Now.ToString("HH:mm:ss"));
    }

    [Route("Validate")]
    [HttpPost]
    public IActionResult Validate(IFormCollection formCollection)
    {
        var validator = new Validator();

        var summary = validator.Validate(formCollection);

        return PartialView("_ValidationSummary", summary);
    }

    [Route("Process")]
    [HttpPut]
    public IActionResult Process(IFormCollection formCollection)
    {
        var validator = new Validator();

        var summary = validator.Validate(formCollection);

        if (summary.IsValid) return Ok("Success");

        return BadRequest("Validation failed");
    }
}