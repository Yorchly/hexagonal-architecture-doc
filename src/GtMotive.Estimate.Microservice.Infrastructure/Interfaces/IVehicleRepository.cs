using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        public Task<Vehicle?> GetVehicleByRented(string rented);
    }
}
