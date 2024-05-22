using System;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle entity.
    /// </summary>
    public class Vehicle : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        public string Model { get; set; } = string.Empty;

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
        public VehicleStatusType Status { get; set; }
    }
}
