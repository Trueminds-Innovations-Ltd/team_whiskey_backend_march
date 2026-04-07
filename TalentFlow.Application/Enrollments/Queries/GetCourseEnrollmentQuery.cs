using System;
using MediatR;
using TalentFlow.Application.Courses.DTOs;

namespace TalentFlow.Application.Enrollments.Queries
{
    // Query to get a course with its enrollments
    public record GetCourseEnrollmentQuery(Guid CourseId) : IRequest<CourseEnrollmentDto>;
}
