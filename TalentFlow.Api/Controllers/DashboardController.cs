using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentFlow.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireLearner")]
public class DashboardController : ControllerBase
{
    [HttpGet]
    public IActionResult GetDashboard()
    {
        var learnerId = User.FindFirst("learner_id")?.Value;
        return Ok(new { learner_id = learnerId, courses = new[] { "Course A", "Course B" } });
    }
}
