using System;
using MediatR;
using TalentFlow.Application.Enrollments.DTOs;

namespace TalentFlow.Application.Enrollments.Queries
{
    // Query to fetch a single enrollment by Id
    public record GetEnrollmentQuery(Guid Id) : IRequest<EnrollmentDto>;
}
