namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for handler a RentVehicle use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">input type.</typeparam>
    public interface IRentVehicleUseCase<in TUseCaseInput>
        : IUseCase<TUseCaseInput>
        where TUseCaseInput : IUseCaseInput
    {
    }
}
