using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentFlow.Application.Enrollments.Commands;
using TalentFlow.Application.Enrollments.DTOs;
using TalentFlow.Application.Enrollments.Queries;
using TalentFlow.Application.Courses.DTOs; // ✅ Correct import

namespace TalentFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/enrollment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollment(Guid id)
        {
            var enrollment = await _mediator.Send(new GetEnrollmentQuery(id));
            if (enrollment == null) return NotFound();

            return Ok(enrollment);
        }

        // GET: api/enrollment/course/{courseId}
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<List<EnrollmentDto>>> GetEnrollmentsByCourse(Guid courseId)
        {
            var enrollments = await _mediator.Send(new GetEnrollmentsByCourseQuery(courseId));
            if (enrollments == null || enrollments.Count == 0) return NotFound();

            return Ok(enrollments);
        }

        // PUT: api/enrollment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(Guid id, [FromBody] UpdateEnrollmentCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var updatedBy = User.FindFirst("learner_id")?.Value ?? "system";
            var enrichedCommand = command with { UpdatedBy = updatedBy };

            var result = await _mediator.Send(enrichedCommand);
            return result ? Ok(new { message = "Enrollment updated" }) : NotFound();
        }

        // DELETE: api/enrollment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(Guid id)
        {
            var deletedBy = User.FindFirst("learner_id")?.Value ?? "system";
            var command = new DeleteEnrollmentCommand(id, deletedBy);

            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Enrollment deleted" }) : NotFound();
        }

        [HttpGet("course-enrollment/{courseId}")]
        public async Task<ActionResult<CourseEnrollmentDto>> GetCourseEnrollment(Guid courseId)
        {
            var enrollment = await _mediator.Send(new GetCourseEnrollmentQuery(courseId));
            if (enrollment == null) return NotFound();

            return Ok(enrollment);
        }

    }
}
