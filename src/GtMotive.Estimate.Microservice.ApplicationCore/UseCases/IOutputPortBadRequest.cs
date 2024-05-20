namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the BadRequest Output Port.
    /// </summary>
    public interface IOutputPortBadRequest : IUseCaseOutput
    {
        /// <summary>
        /// Writes to BadRequest Output.
        /// </summary>
        /// <param name="message">The Output Port Message.</param>
        public void BadRequestHandle(string message);
    }
}
