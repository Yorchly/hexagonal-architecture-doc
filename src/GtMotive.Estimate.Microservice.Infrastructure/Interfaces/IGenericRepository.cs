using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
    {
        public IMongoCollection<T> GetCollection();

        public Task<List<T>> GetAsync();

        public Task<T?> GetAsync(Guid id);

        public Task CreateAsync(T entity);

        public Task UpdateAsync(Guid id, T entity);

        public Task RemoveAsync(Guid id);
    }
}
