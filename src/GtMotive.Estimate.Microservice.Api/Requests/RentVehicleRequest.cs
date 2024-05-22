using System;
using GtMotive.Estimate.Microservice.Api.UseCases;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class RentVehicleRequest : BaseRequest<IWebApiPresenter>
    {
        public RentVehicleRequest()
        {
        }

        public RentVehicleRequest(Guid id, string rentedBy)
        {
            Id = id;
            RentedBy = rentedBy;
        }

        /// <summary>
        /// Gets or sets the RentedBy.
        /// </summary>
        public string RentedBy { get; set; } = string.Empty;
    }
}
