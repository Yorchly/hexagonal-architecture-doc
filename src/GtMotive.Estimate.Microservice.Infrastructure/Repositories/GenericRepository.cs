using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Exceptions;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        protected GenericRepository(MongoService mongoService, string collectionName)
        {
            if (mongoService is null)
            {
                throw new InfrastructureException("Error getting mongoService.");
            }

            var mongoDatabase =
                mongoService.MongoDatabase ??
                throw new InfrastructureException("Error initializing database.");

            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public virtual async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public virtual async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public virtual async Task<T?> GetAsync(Guid id) =>
            await _collection
                .Find((T entity) => entity.Id == id)
                .FirstOrDefaultAsync();

        public virtual async Task RemoveAsync(Guid id) =>
            await _collection
                .DeleteOneAsync((T entity) => entity.Id == id);

        public virtual async Task UpdateAsync(Guid id, T entity) =>
            await _collection
                .ReplaceOneAsync((T entity) => entity.Id == id, entity);
    }
}
