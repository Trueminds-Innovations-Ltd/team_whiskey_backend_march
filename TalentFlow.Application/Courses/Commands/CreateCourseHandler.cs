// Application/Courses/Handlers/CreateCourseHandler.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Courses.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Courses.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseRepository _repo;

        public CreateCourseHandler(ICourseRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken ct)
        {
            var course = new Course(request.Title, request.Description, request.Slug);
            await _repo.AddAsync(course, ct);
            return course.Id; // ✅ returns Guid
        }
    }
}
