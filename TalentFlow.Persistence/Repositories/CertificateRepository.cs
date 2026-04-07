using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Persistence.Repositories
{
    public class CertificateRepository : BaseRepository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(TalentFlowDbContext context) : base(context) { }

        public async Task<List<Certificate>> GetByLearnerIdAsync(Guid learnerId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(c => c.LearnerId == learnerId)
                .ToListAsync(cancellationToken);
        }
    }
}
