using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface ILessonRepository
    {
        Task AddAsync(Lesson lesson, CancellationToken cancellationToken);
        Task<Lesson?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAsync(Lesson lesson, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        // ✅ Add these methods
        Task<List<Lesson>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken);

        Task<(List<Lesson> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);
    }
}
