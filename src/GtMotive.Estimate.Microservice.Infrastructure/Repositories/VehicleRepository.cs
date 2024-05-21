using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(MongoService mongoService)
            : base(mongoService, collectionName: "Vehicles")
        {
        }

        public async Task<Vehicle?> GetVehicleByRented(string rentedBy) =>
            await GetCollection()
                .Find(vehicle => vehicle.RentedBy == rentedBy)
                .FirstOrDefaultAsync();
    }
}
