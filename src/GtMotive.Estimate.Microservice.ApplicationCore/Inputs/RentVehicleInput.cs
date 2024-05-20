using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Inputs
{
    /// <summary>
    /// RentVehicleInput class.
    /// </summary>
    public class RentVehicleInput : BaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="id">id input.</param>
        /// <param name="rentedBy">rentedBy input.</param>
        public RentVehicleInput(
            Guid id,
            string rentedBy)
        {
            Id = id;
            RentedBy = rentedBy;
        }

        /// <summary>
        /// Gets or sets the RentedBy.
        /// </summary>
        public string RentedBy { get; set; }
    }
}
