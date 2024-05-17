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

            var mongoClient = new MongoClient(options.Value.ConnectionString);
            MongoDatabase = mongoClient.GetDatabase(options.Value.MongoDbDatabaseName);
        }

        public IMongoDatabase MongoDatabase { get; }
    }
}
