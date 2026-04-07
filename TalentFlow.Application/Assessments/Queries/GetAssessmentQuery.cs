using System;
using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Queries
{
    // Query to fetch a single assessment by Id
    public record GetAssessmentQuery(Guid Id) : IRequest<AssessmentDto>;
}
