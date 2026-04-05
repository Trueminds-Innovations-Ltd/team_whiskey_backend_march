using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentFlow.Application.Assessments.Commands;
using TalentFlow.Application.Assessments.Queries;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssessmentController(IMediator mediator) => _mediator = mediator;

        /// <summary>Create a new assessment</summary>
        [HttpPost]
        public async Task<ActionResult<AssessmentDto>> CreateAssessment(CreateAssessmentCommand command)
        {
            var assessment = await _mediator.Send(command);
            return Ok(assessment);
        }

        /// <summary>Get assessment by ID</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentDto>> GetAssessmentById(Guid id)
        {
            var assessment = await _mediator.Send(new GetAssessmentByIdQuery(id));
            return assessment is null ? NotFound() : Ok(assessment);
        }

        /// <summary>Get all assessments</summary>
        [HttpGet]
        public async Task<ActionResult<List<AssessmentDto>>> GetAllAssessments()
        {
            var assessments = await _mediator.Send(new GetAllAssessmentsQuery());
            return Ok(assessments);
        }

        /// <summary>Add a question to an assessment</summary>
        [HttpPost("{id}/questions")]
        public async Task<ActionResult> AddQuestion(Guid id, AddQuestionCommand command)
        {
            if (id != command.AssessmentId) return BadRequest("Assessment ID mismatch");
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest("Failed to add question");
        }
    }
}
