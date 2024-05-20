using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class CreateVehicleRequest : BaseRequest<IWebApiPresenter>
    {
        public CreateVehicleRequest(
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
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        [Required]
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
