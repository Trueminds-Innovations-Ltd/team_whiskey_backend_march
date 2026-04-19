using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Interfaces
{
    public interface ILearningWorkRepository
    {
        Task<LearningWork?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<List<LearningWork>> GetByUserAsync(Guid userId, CancellationToken ct);
        Task AddAsync(LearningWork work, CancellationToken ct);
        Task UpdateAsync(LearningWork work, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}
