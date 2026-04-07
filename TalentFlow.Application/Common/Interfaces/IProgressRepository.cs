using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface IProgressRepository : IRepository<Progress>
    {
        Task<Progress?> GetByLearnerAndCourseAsync(Guid learnerId, Guid courseId, CancellationToken cancellationToken);
    }
}
