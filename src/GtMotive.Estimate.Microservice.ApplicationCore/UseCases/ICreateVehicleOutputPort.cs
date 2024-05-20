namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Create Vehicle Output port.
    /// </summary>
    /// <typeparam name="TUseCaseOutput">Tyoe of the use case response dto.</typeparam>
    public interface ICreateVehicleOutputPort<in TUseCaseOutput> :
        IOutputPortStandard<TUseCaseOutput>,
        IOutputPortBadRequest
        where TUseCaseOutput : IUseCaseOutput
    {
    }
}
