using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<List<Team>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
