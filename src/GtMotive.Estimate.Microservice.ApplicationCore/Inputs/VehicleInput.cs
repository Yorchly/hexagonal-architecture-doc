using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs.ValueObjects.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Inputs
{
    /// <summary>
    /// VehicleInput class.
    /// </summary>
    public class VehicleInput : BaseInput
    {
        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        public CreatedAt CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the RentedBy.
        /// </summary>
        public string? RentedBy { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [Required]
        public VehicleStatusType Status { get; set; }
    }
}
