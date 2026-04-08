// TalentFlow.Persistence.Repositories
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

        public async Task AddAsync(Instructor instructor, CancellationToken cancellationToken)
        {
            await _context.Instructors.AddAsync(instructor, cancellationToken);
        }

        public async Task<Instructor?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Instructors.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task UpdateAsync(Instructor instructor, CancellationToken cancellationToken)
        {
            _context.Instructors.Update(instructor);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var instructor = await _context.Instructors.FindAsync(new object[] { id }, cancellationToken);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
            }
        }

        public async Task<List<Instructor>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Instructors.ToListAsync(cancellationToken);
        }
    }
}
