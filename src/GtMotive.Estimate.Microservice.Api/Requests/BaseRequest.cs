using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Requests
{
    /// <summary>
    /// BaseRequest class.
    /// </summary>
    /// <typeparam name="T">IWebApiPresenter type.</typeparam>
    public class BaseRequest<T> : IRequest<T>
        where T : IWebApiPresenter
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }
    }
}
