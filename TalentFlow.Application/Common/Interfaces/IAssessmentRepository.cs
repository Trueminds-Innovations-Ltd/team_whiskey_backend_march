using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface IAssessmentRepository
    {
        Task<Assessment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Assessment>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default);
        Task AddAsync(Assessment assessment, CancellationToken cancellationToken = default);
        Task UpdateAsync(Assessment assessment, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
