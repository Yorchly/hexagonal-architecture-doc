using GtMotive.Estimate.Microservice.Api.UseCases;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class RentVehicleRequest : BaseRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the RentedBy.
        /// </summary>
        public string RentedBy { get; set; } = string.Empty;
    }
}
