using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetByAssessmentIdAsync(Guid assessmentId, CancellationToken cancellationToken);
        Task UpdateAsync(Question question, CancellationToken ct);
    }
}
