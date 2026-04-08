using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly TalentFlowDbContext _context;

        public LessonRepository(TalentFlowDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lesson lesson, CancellationToken cancellationToken)
        {
            await _context.Lessons.AddAsync(lesson, cancellationToken);
        }

        public async Task<Lesson?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Lessons.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task UpdateAsync(Lesson lesson, CancellationToken cancellationToken)
        {
            _context.Lessons.Update(lesson);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var lesson = await _context.Lessons.FindAsync(new object[] { id }, cancellationToken);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }
        }

        // ✅ Implementation for GetByCourseIdAsync
        public async Task<List<Lesson>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return await _context.Lessons
                .Where(l => l.CourseId == courseId)
                .ToListAsync(cancellationToken);
        }

        // ✅ Implementation for GetPagedAsync
        public async Task<(List<Lesson> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var query = _context.Lessons.AsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return (items, totalCount);
        }
    }
}
