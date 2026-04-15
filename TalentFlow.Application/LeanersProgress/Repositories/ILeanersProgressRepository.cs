using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.LeanersProgress.Repositories
{
    public interface ILeanersProgressRepository
    {
        Task<LessonProgress?> GetAsync(Guid lessonId, Guid userId, CancellationToken ct);
        Task AddAsync(LessonProgress progress, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}