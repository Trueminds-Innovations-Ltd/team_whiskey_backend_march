using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<(List<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);
    }
}
