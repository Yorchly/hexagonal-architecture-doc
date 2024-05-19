namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface to define the Get All Vehicles Output port.
    /// </summary>
    /// <typeparam name="TUseCaseOutput">Tyoe of the use case response dto.</typeparam>
    public interface IGetAllVehicleOutputPort<in TUseCaseOutput> :
        IOutputPortStandard<TUseCaseOutput>
        where TUseCaseOutput : IUseCaseOutput
    {
    }
}
