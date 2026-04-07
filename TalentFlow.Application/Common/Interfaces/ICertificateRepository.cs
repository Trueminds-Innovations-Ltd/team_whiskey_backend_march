using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface ICertificateRepository : IRepository<Certificate>
    {
        Task<List<Certificate>> GetByLearnerIdAsync(Guid learnerId, CancellationToken cancellationToken);
    }
}
