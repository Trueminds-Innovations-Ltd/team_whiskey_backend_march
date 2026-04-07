using System;
using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Commands
{
    // Command to create a new assessment
    public record CreateAssessmentCommand(
        Guid CourseId,
        string Title,
        string Instructions
    ) : IRequest<AssessmentDto>;
}
