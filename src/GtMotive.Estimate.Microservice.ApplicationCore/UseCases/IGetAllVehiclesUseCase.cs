namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for handler a getAllVehicles use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">Tyoe of the input message.</typeparam>
    public interface IGetAllVehiclesUseCase<in TUseCaseInput> :
        IUseCase<TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
    }
}
