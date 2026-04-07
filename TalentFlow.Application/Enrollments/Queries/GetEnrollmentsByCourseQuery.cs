using System;
using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Enrollments.DTOs;

namespace TalentFlow.Application.Enrollments.Queries
{
    public record GetEnrollmentsByCourseQuery(Guid CourseId) : IRequest<List<EnrollmentDto>>;
}
