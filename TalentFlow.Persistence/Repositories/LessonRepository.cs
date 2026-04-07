using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Persistence.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(TalentFlowDbContext context) : base(context) { }

        public async Task<List<Lesson>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(l => l.CourseId == courseId)
                .OrderBy(l => l.Order)
                .ToListAsync(cancellationToken);
        }
    }
}
