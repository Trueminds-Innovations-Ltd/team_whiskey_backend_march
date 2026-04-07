using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TalentFlowDbContext _context;

        public CourseRepository(TalentFlowDbContext context)
        {
            _context = context;
        }

        // Persistence/Repositories/CourseRepository.cs
        public async Task<Course?> GetBySlugAsync(string slug, CancellationToken ct = default)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Slug == slug && !c.IsDeleted, ct);
        }


        public async Task<List<Course>> GetByLearnerIdAsync(Guid learnerId, CancellationToken ct = default)
        {
            return await _context.Courses
                .Where(c => c.Enrollments.Any(e => e.UserId == learnerId && !e.IsDeleted))
                .ToListAsync(ct);
        }

        public async Task<List<Course>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Courses.Where(c => !c.IsDeleted).ToListAsync(ct);
        }

        public async Task<Course?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Courses.FindAsync(new object[] { id }, ct);
        }

        public async Task AddAsync(Course course, CancellationToken ct = default)
        {
            await _context.Courses.AddAsync(course, ct);
        }

        public Task UpdateAsync(Course course, CancellationToken ct = default)
        {
            _context.Courses.Update(course);
            return Task.CompletedTask;
        }

        // Persistence/Repositories/CourseRepository.cs
        public async Task SoftDeleteAsync(Course course, CancellationToken ct = default)
        {
            course.SoftDelete(course.DeletedBy ?? "system");
            _context.Courses.Update(course);
            await _context.SaveChangesAsync(ct);
        }

    }
}

