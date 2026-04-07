using System;
using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Queries
{
    // Query to fetch all assessments for a given course
    public record GetAssessmentsByCourseQuery(Guid CourseId) : IRequest<List<AssessmentDto>>;
}
