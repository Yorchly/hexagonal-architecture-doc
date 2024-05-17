using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<List<T>> GetAsync();

        public Task<T?> GetAsync(Guid id);

        public Task CreateAsync(T entity);

        public Task UpdateAsync(Guid id, T entity);

        public Task RemoveAsync(Guid id);
    }
}
