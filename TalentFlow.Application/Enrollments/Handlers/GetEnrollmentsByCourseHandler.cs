using MediatR;
using TalentFlow.Application.Enrollments.Queries;
using TalentFlow.Application.Enrollments.DTOs;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Enrollments.Handlers
{
    public class GetEnrollmentsByCourseHandler
        : IRequestHandler<GetEnrollmentsByCourseQuery, List<EnrollmentDto>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetEnrollmentsByCourseHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<List<EnrollmentDto>> Handle(GetEnrollmentsByCourseQuery request, CancellationToken cancellationToken)
        {
            var enrollments = await _enrollmentRepository.GetByCourseIdAsync(request.CourseId, cancellationToken);

            return enrollments.Select(e => new EnrollmentDto
            {
                UserId = e.UserId,
                CourseId = e.CourseId,
                EnrolledAt = e.EnrolledAt
            }).ToList();
        }
    }
}
