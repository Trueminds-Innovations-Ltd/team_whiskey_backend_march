using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;
using TalentFlow.Persistence;
using TalentFlow.Persistence.Repositories;

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(TalentFlowDbContext context) : base(context) { }

    public async Task<List<Question>> GetByAssessmentIdAsync(Guid assessmentId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Where(q => q.AssessmentId == assessmentId)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Question question, CancellationToken cancellationToken)
    {
        _dbSet.Update(question);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
