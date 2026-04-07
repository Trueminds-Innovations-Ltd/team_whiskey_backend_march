using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Courses.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Courses.Handlers
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseRepository _repo;

        public DeleteCourseHandler(ICourseRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken ct)
        {
            // Fetch course by Id (not Slug)
            var course = await _repo.GetByIdAsync(request.Id, ct);
            if (course == null || course.IsDeleted) return false;

            // Controlled soft delete with audit info
            course.SoftDelete(request.DeletedBy);

            // Persist changes
            await _repo.SoftDeleteAsync(course, ct);
            return true;
        }
    }
}
