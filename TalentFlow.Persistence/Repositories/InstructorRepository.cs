using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly TalentFlowDbContext _context;

        public InstructorRepository(TalentFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        public async Task<List<Instructor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Instructors.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            await _context.Instructors.AddAsync(instructor, cancellationToken);
        }

        public Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken = default)
        {
            _context.Instructors.Update(instructor);
            return Task.CompletedTask;
        }
    }
}
