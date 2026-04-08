using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

public interface IQuestionRepository : IRepository<Question>
{
    Task<List<Question>> GetByAssessmentIdAsync(Guid assessmentId, CancellationToken cancellationToken);
    Task UpdateAsync(Question question, CancellationToken ct);
}
