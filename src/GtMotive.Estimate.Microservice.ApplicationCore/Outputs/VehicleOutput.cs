using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Outputs
{
    /// <summary>
    /// VehicleOutput class.
    /// </summary>
    public class VehicleOutput : BaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleOutput"/> class.
        /// </summary>
        /// <param name="brand">brand input.</param>
        /// <param name="model">model input.</param>
        /// <param name="createdAt">createdAt input.</param>
        /// <param name="rentedBy">rentedBy input.</param>
        /// <param name="status">status input.</param>
        public VehicleOutput(
            string brand,
            string model,
            DateTime createdAt,
            string rentedBy,
            VehicleStatusType status)
        {
            Brand = brand;
            Model = model;
            CreatedAt = createdAt;
            RentedBy = rentedBy;
            Status = status;
        }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        public DateTime CreatedAt { get; set; }

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
