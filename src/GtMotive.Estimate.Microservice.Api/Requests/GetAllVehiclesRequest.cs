using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Domain.Enums;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class GetAllVehiclesRequest : BaseRequest<IWebApiPresenter>
    {
        public GetAllVehiclesRequest(
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
        public VehicleStatusType Status { get; set; }
    }
}
