using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class LearningWorkRepository : ILearningWorkRepository
    {
        private readonly TalentFlowDbContext _db;

        public LearningWorkRepository(TalentFlowDbContext db)
        {
            _db = db;
        }

        public async Task<LearningWork?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _db.LearningWorks.FindAsync(new object[] { id }, ct);
        }

        public async Task<List<LearningWork>> GetByUserAsync(Guid userId, CancellationToken ct)
        {
            return await _db.LearningWorks
                .Where(w => w.AssignedTo == userId)
                .ToListAsync(ct);
        }

        public async Task AddAsync(LearningWork work, CancellationToken ct)
        {
            await _db.LearningWorks.AddAsync(work, ct);
        }

        public async Task UpdateAsync(LearningWork work, CancellationToken ct)
        {
            _db.LearningWorks.Update(work);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var work = await _db.LearningWorks.FindAsync(new object[] { id }, ct);
            if (work != null)
            {
                _db.LearningWorks.Remove(work);
            }
        }

    }
}
