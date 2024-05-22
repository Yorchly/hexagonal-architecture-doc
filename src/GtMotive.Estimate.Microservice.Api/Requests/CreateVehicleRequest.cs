using System;
using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    public class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        public CreateVehicleRequest(
            string brand,
            string model,
            DateTime createdAt)
        {
            Brand = brand;
            Model = model;
            CreatedAt = createdAt;
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
    }
}
