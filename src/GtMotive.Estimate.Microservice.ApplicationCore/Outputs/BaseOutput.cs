using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Outputs
{
    /// <summary>
    /// BaseOutput class.
    /// </summary>
    public class BaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
