using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.LeanersProgress.Repositories;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class LessonProgressRepository : ILeanersProgressRepository
    {
        private readonly TalentFlowDbContext _db;

        public LessonProgressRepository(TalentFlowDbContext db)
        {
            _db = db;
        }

        public async Task<LessonProgress?> GetAsync(Guid lessonId, Guid userId, CancellationToken ct)
        {
            return await _db.LessonProgresses
                .FirstOrDefaultAsync(x => x.LessonId == lessonId && x.UserId == userId, ct);
        }

        public async Task AddAsync(LessonProgress progress, CancellationToken ct)
        {
            await _db.LessonProgresses.AddAsync(progress, ct);
        }

        // ✅ THIS IS THE MISSING METHOD
        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _db.SaveChangesAsync(ct);
        }
    }
}