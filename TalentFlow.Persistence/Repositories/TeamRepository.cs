using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Persistence.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(TalentFlowDbContext context) : base(context) { }

        public async Task<List<Team>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(t => t.Name.Contains(name))
                .ToListAsync(cancellationToken);
        }
    }
}
