using System.Collections.Generic;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Outputs
{
    /// <summary>
    /// VehicleCollectionOutput class.
    /// </summary>
    public class VehicleCollectionOutput : IUseCaseOutput
    {
        private readonly ICollection<VehicleOutput> _vehicleOutput;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleCollectionOutput"/> class.
        /// </summary>
        /// <param name="vehicleOutput">vehicleOutput parameter.</param>
        public VehicleCollectionOutput(ICollection<VehicleOutput> vehicleOutput)
        {
            _vehicleOutput = vehicleOutput;
        }

        /// <summary>
        /// Get vehicle output list.
        /// </summary>
        /// <returns>list of vehicle outputs.</returns>
        public ICollection<VehicleOutput> ToList() => _vehicleOutput;
    }
}
