using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(classMap =>
            {
                classMap.AutoMap();
                classMap
                    .MapIdMember((BaseEntity v) => v.Id)
                    .SetIdGenerator(CombGuidGenerator.Instance);
            });

            var connectionString =
                Environment.GetEnvironmentVariable(options.Value.ConnectionString);
            var mongoClient = new MongoClient(connectionString);

            var databaseName =
                Environment.GetEnvironmentVariable(options.Value.MongoDbDatabaseName);
            MongoDatabase = mongoClient.GetDatabase(databaseName);
        }

        public IMongoDatabase MongoDatabase { get; }
    }
}
