using System;
using GtMotive.Estimate.Microservice.ApplicationCore.Exceptions;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Inputs.ValueObjects.Vehicle
{
    /// <summary>
    /// CreatedAt struct.
    /// </summary>
    public readonly struct CreatedAt
    {
        private readonly DateTime _createdAt;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedAt"/> struct.
        /// </summary>
        /// <param name="createdAt">createdAt input.</param>
        /// <exception cref="CoreException">Could throw a CoreException.</exception>
        public CreatedAt(DateTime createdAt)
        {
            var maxYear = DateTime.Now.Year + 5;

            if (createdAt.Year > maxYear)
            {
                throw new CoreException($"The vehicle year of " +
                    $"creation cannot be greater than {maxYear}");
            }

            _createdAt = createdAt;
        }

        /// <summary>
        /// Transform CreatedAt element to DateTime.
        /// </summary>
        /// <returns>DateTime.</returns>
        public readonly DateTime ToDateTime() => _createdAt;
    }
}
