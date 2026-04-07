using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Persistence.Repositories
{
    public class ProgressRepository : BaseRepository<Progress>, IProgressRepository
    {
        public ProgressRepository(TalentFlowDbContext context) : base(context) { }

        public async Task<Progress?> GetByLearnerAndCourseAsync(Guid learnerId, Guid courseId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .FirstOrDefaultAsync(p => p.LearnerId == learnerId && p.CourseId == courseId, cancellationToken);
        }
    }
}
