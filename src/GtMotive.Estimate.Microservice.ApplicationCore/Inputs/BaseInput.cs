using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Inputs
{
    /// <summary>
    /// BaseInput class.
    /// </summary>
    public class BaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
