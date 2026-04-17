using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentFlow.Application.Dashboard.Learner.DTOs;
using TalentFlow.Application.Dashboard.Learner.Queries;

[ApiController]
[Route("api/dashboard/learner")]
public class LearnerDashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public LearnerDashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{learnerId}")]
    public async Task<ActionResult<LearnerDashboardDto>> Get(string learnerId, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetLearnerDashboardQuery(learnerId), ct);
        return Ok(result);
    }
}
