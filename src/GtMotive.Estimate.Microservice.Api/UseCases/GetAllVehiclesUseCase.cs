using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    internal class GetAllVehiclesUseCase :
        IGetAllVehiclesUseCase<VehicleInput>
    {
        public Task Execute(VehicleInput input)
        {
            throw new System.NotImplementedException();
        }
    }
}
