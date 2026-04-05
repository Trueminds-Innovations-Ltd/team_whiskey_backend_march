using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly TalentFlowDbContext _context;

        public AssessmentRepository(TalentFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Assessment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Assessments
                .Include(a => a.Questions)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task<List<Assessment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Assessments
                .Include(a => a.Questions)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Assessment assessment, CancellationToken cancellationToken = default)
        {
            await _context.Assessments.AddAsync(assessment, cancellationToken);
        }

        public Task UpdateAsync(Assessment assessment, CancellationToken cancellationToken = default)
        {
            _context.Assessments.Update(assessment);
            return Task.CompletedTask;
        }
    }
}
