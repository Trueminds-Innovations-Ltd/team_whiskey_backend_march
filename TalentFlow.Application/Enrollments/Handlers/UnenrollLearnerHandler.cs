using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Enrollments.Commands;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Enrollments.Handlers
{
    public class UnenrollLearnerHandler : IRequestHandler<UnenrollLearnerCommand, bool>
    {
        private readonly IEnrollmentRepository _enrollmentRepo;

        public UnenrollLearnerHandler(IEnrollmentRepository enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo ?? throw new ArgumentNullException(nameof(enrollmentRepo));
        }

        public async Task<bool> Handle(UnenrollLearnerCommand request, CancellationToken ct)
        {
            var enrollments = await _enrollmentRepo.GetByCourseIdAsync(request.CourseId, ct);
            var enrollment = enrollments.FirstOrDefault(e => e.UserId == request.UserId && !e.IsDeleted);

            if (enrollment == null) return false;

            enrollment.SoftDelete(request.DeletedBy);
            await _enrollmentRepo.UpdateAsync(enrollment, ct);

            return true;
        }
    }
}
