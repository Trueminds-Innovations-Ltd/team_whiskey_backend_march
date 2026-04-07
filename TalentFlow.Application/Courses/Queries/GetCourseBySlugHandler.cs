using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Courses.DTOs;
using TalentFlow.Application.Courses.Queries;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Courses.Handlers
{
    public class GetCourseBySlugHandler : IRequestHandler<GetCourseBySlugQuery, CourseDto?>
    {
        private readonly ICourseRepository _repo;

        public GetCourseBySlugHandler(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<CourseDto?> Handle(GetCourseBySlugQuery request, CancellationToken ct)
        {
            var course = await _repo.GetBySlugAsync(request.Slug, ct);
            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Slug = course.Slug,
                CreatedAt = course.CreatedAt,
                UpdatedBy = course.UpdatedBy,
                UpdatedAt = course.UpdatedAt,
                DeletedBy = course.DeletedBy,
                DeletedAt = course.DeletedAt,
                IsDeleted = course.IsDeleted
            };
        }
    }
}
