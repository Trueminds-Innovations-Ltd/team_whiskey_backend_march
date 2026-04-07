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
    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(TalentFlowDbContext context) : base(context) { }

        public async Task<List<Video>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Where(v => v.LessonId == lessonId)
                .ToListAsync(cancellationToken);
        }
    }
}
