using Microsoft.EntityFrameworkCore;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly TalentFlowDbContext _context;

        public EnrollmentRepository(TalentFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<List<Enrollment>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            return await _context.Enrollments.Where(e => e.CourseId == courseId).ToListAsync(cancellationToken);
        }

        public async Task<List<Enrollment>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Enrollments.Where(e => e.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Enrollment enrollment, CancellationToken cancellationToken = default)
        {
            await _context.Enrollments.AddAsync(enrollment, cancellationToken);
        }

        public Task UpdateAsync(Enrollment enrollment, CancellationToken cancellationToken = default)
        {
            _context.Enrollments.Update(enrollment);
            return Task.CompletedTask;
        }
    }
}
