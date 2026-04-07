using System;
using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Enrollments.DTOs;

namespace TalentFlow.Application.Courses.Queries
{
    public record GetCourseEnrollmentQuery(Guid CourseId) : IRequest<List<EnrollmentDto>>;
}
