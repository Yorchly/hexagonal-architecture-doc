namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Rent Vehicle Output port.
    /// </summary>
    /// <typeparam name="TUseCaseOutput">Tyoe of the use case response dto.</typeparam>
    public interface IRentVehicleOutputPort<in TUseCaseOutput> :
        IOutputPortStandard<TUseCaseOutput>,
        IOutputPortNotFound,
        IOutputPortBadRequest
        where TUseCaseOutput : IUseCaseOutput
    {
    }
}
