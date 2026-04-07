using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface IVideoRepository : IRepository<Video>
    {
        Task<List<Video>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken);
    }
}
